import torch
import torch.nn as nn
import torch.nn.functional as F
import numpy as np


class ChannelAttentionNetwork(nn.Module):
    def __init__(self, channels):
        super(ChannelAttentionNetwork, self).__init__()
        self.conv_layer = nn.Conv1d(channels, channels, kernel_size=3, padding=1)
        self.dense_layer = nn.Linear(channels, channels)

    def channel_attention(self, x):
        # x: (batch_size, channels, time_points)
        out = self.conv_layer(x)              # (B, C, T)
        out = out.mean(dim=2)                 # Global Avg Pooling -> (B, C)
        attn = self.dense_layer(out)          # (B, C)
        attn = F.softmax(attn, dim=1)         # Soft attention weights
        attn = attn.unsqueeze(2)              # (B, C, 1)
        return x * attn                       # Apply attention weights


class SpatialAttentionNetwork(nn.Module):
    def __init__(self, channels):
        super(SpatialAttentionNetwork, self).__init__()
        self.conv_layer = nn.Conv1d(channels, channels, kernel_size=3, padding=1)
        self.max_pool = nn.MaxPool1d(kernel_size=2)

    def spatial_attention(self, x):
        # x: (batch_size, channels, time_points)
        out = self.conv_layer(x)              # (B, C, T)
        out = self.max_pool(out)              # (B, C, T/2)
        return out


class TCSNet(nn.Module):
    def __init__(self, channels=32):
        super(TCSNet, self).__init__()
        self.channel_attention = ChannelAttentionNetwork(channels)
        self.spatial_attention = SpatialAttentionNetwork(channels)

    def extract_features(self, eeg_signals):
        # eeg_signals: (batch_size, channels, time_points)
        channel_features = self.channel_attention.channel_attention(eeg_signals)
        spatial_features = self.spatial_attention.spatial_attention(eeg_signals)

        # Align time dimensions
        min_len = min(channel_features.shape[2], spatial_features.shape[2])
        channel_features = channel_features[:, :, :min_len]
        spatial_features = spatial_features[:, :, :min_len]

        combined = torch.cat([channel_features, spatial_features], dim=1)  # (B, 2C, T')
        combined_flat = combined.view(combined.size(0), -1)  # Flatten
        return combined_flat  # (B, 2C * T')


class MNFSFeatureSelector:
    def __init__(self, population_size=50, max_iterations=100, threshold=0.5):
        self.population_size = population_size
        self.max_iterations = max_iterations
        self.threshold = threshold

    def initialize_population(self, feature_space):
        return np.random.rand(self.population_size, feature_space.shape[1])

    def calculate_food_density(self, population, fitness_func):
        densities = np.zeros(len(population))
        for i, individual in enumerate(population):
            neighbors = [j for j, other in enumerate(population)
                         if np.linalg.norm(individual - other) < self.threshold]
            densities[i] = len(neighbors)
        return densities

    def optimize_features(self, features, fitness_func=None):
        features_np = features.detach().cpu().numpy()
        population = self.initialize_population(features_np)

        for _ in range(self.max_iterations):
            densities = self.calculate_food_density(population, fitness_func)
            # Упрощённая логика: просто выбираем индивидуума с наибольшей плотностью
            best_idx = np.argmax(densities)
            best_features = population[best_idx]

        # Применим маску отборщика к признакам
        selected = features_np * best_features
        return torch.tensor(selected, dtype=torch.float32)


class HHNN(nn.Module):
    def __init__(self, input_size, hidden_size, output_size):
        super(HHNN, self).__init__()
        self.input_layer = nn.Linear(input_size, hidden_size)
        self.hidden_layer = nn.Linear(hidden_size, hidden_size)
        self.output_layer = nn.Linear(hidden_size, output_size)

    def hinge_activation(self, x):
        return torch.max(torch.zeros_like(x), x)

    def forward(self, x):
        x = self.hinge_activation(self.input_layer(x))
        x = self.hinge_activation(self.hidden_layer(x))
        x = self.output_layer(x)
        return x


class NeurologicalDiagnosisSystem:
    def __init__(self, eeg_channels=32, eeg_timepoints=128, hidden_size=50, output_size=3):
        self.feature_extractor = TCSNet(channels=eeg_channels)
        self.feature_selector = MNFSFeatureSelector()
        self.input_size = 2 * eeg_channels * (eeg_timepoints // 2)  # Flattened shape after attention
        self.classifier = HHNN(input_size=self.input_size, hidden_size=hidden_size, output_size=output_size)

    def diagnose(self, eeg_signals):
        # eeg_signals: (batch_size, channels, time_points)
        features = self.feature_extractor.extract_features(eeg_signals)
        selected_features = self.feature_selector.optimize_features(features)
        diagnosis = self.classifier(selected_features)
        return diagnosis


# === Пример использования ===
if __name__ == "__main__":
    # Параметры
    batch_size = 8
    channels = 32
    time_points = 128

    eeg_data = torch.randn(batch_size, channels, time_points)

    system = NeurologicalDiagnosisSystem(eeg_channels=channels, eeg_timepoints=time_points)
    output = system.diagnose(eeg_data)

    print("Diagnosis output shape:", output.shape)  # Ожидается (batch_size, output_size)
