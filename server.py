

# from flask import Flask, request

# app = Flask(__name__)

# @app.route('/api/upload', methods=['POST'])
# def upload_file():
#     file_content = request.data.decode('utf-8')  # Получаем содержимое файла
#     # Здесь можно обработать данные
#     print(file_content)  # Например, выводим в консоль
#     return 'File received', 200

# if __name__ == '__main__':
#     app.run(debug=True)


from flask import Flask, request, jsonify
import tensorflow as tf
from keras.utils import custom_object_scope
import pandas as pd
import numpy as np
from sklearn.impute import SimpleImputer
import logging
from keras.models import Model, Sequential
import traceback
import chardet
import json

# Настройка логирования
logging.basicConfig(level=logging.INFO)

class HHNN(tf.keras.Model):
    def __init__(self, num_features=None, num_classes=3, **kwargs):
        super(HHNN, self).__init__(**kwargs)
        
        self.num_features = num_features
        self.num_classes = num_classes
        
        # Создаем слои с проверкой num_features
        if num_features is not None and num_features > 0:
            self.dense1 = tf.keras.layers.Dense(min(64, max(16, num_features // 2)), activation='relu', input_shape=(num_features,))
            self.dense2 = tf.keras.layers.Dense(min(32, max(8, num_features // 4)), activation='relu')
            self.output_layer = tf.keras.layers.Dense(num_classes, activation='softmax')
        else:
            raise ValueError("Количество признаков должно быть положительным")

    def call(self, inputs):
        x = self.dense1(inputs)
        x = self.dense2(x)
        return self.output_layer(x)

    def build(self, input_shape):
        super().build(input_shape)

def create_adaptive_model(num_features):
    """
    Создание адаптивной модели с динамическим количеством входных признаков
    """
    model = HHNN(num_features=num_features)
    
    # Компиляция модели
    model.compile(
        optimizer='adam',
        loss='categorical_crossentropy',
        metrics=['accuracy']
    )
    
    return model

def detect_encoding(file_content):
    """
    Определение кодировки файла
    """
    try:
        result = chardet.detect(file_content.encode())
        return result['encoding']
    except Exception as e:
        logging.error(f"Ошибка определения кодировки: {e}")
        return 'utf-8'  # Кодировка по умолчанию

def preprocess_data(file_content):
    logging.info("Начало предобработки данных")
    
    try:
        # Парсим JSON-данные
        data = json.loads(file_content)
        
        # Преобразуем JSON в DataFrame
        df = pd.DataFrame(data)
        
        # Преобразуем все столбцы в числовой формат
        for col in df.columns:
            df[col] = pd.to_numeric(df[col], errors='coerce')
        
        # Проверяем, есть ли числовые столбцы
        numeric_df = df.select_dtypes(include=[np.number])
        
        if numeric_df.empty:
            raise ValueError("Нет числовых столбцов")
        
        # Обработка пропусков
        imputer = SimpleImputer(strategy='mean')
        processed_data = imputer.fit_transform(numeric_df)
        
        logging.info(f"Предобработка успешна. Размер данных: {processed_data.shape}")
        
        return processed_data
    
    except Exception as e:
        logging.error(f"Ошибка предобработки: {str(e)}")
        logging.error(f"Трассировка: {traceback.format_exc()}")
        raise



# Инициализация приложения Flask
app = Flask(__name__)

@app.route('/api/predict', methods=['POST'])
def predict_disease():
    try:
        file_content = request.data.decode('utf-8')
        
        try:
            processed_data = preprocess_data(file_content)
        except Exception as preprocess_error:
            logging.error(f"Ошибка предобработки: {str(preprocess_error)}")
            return jsonify({'error': 'Не удалось обработать входные данные'}), 400
        
        if processed_data.shape[0] == 0 or processed_data.shape[1] == 0:
            return jsonify({'error': 'Нет данных для предсказания'}), 400
        
        num_features = processed_data.shape[1]
        model = create_adaptive_model(num_features)

        # Здесь можно обучить модель на ваших данных, если нужно
        # model.fit(...)

        # Предсказания
        predictions = model.predict(processed_data)
        predicted_classes = np.argmax(predictions, axis=1)
        
        class_names = ['Нейротипичные', 'Эпилепсия', 'Аутизм']
        
        # Определение наиболее частого класса
        unique, counts = np.unique(predicted_classes, return_counts=True)
        majority_class_index = unique[np.argmax(counts)]
        majority_class_name = class_names[majority_class_index]

        # Средняя вероятность для этого класса
        majority_probs = predictions[:, majority_class_index]
        avg_probability = float(np.mean(majority_probs)) * 100  # в процентах

        logging.info(f"Финальный диагноз: {majority_class_name} ({avg_probability:.2f}%)")

        return jsonify({
            'diagnosis': majority_class_name,
            'confidence_percent': round(avg_probability, 2)
        }), 200, {'Content-Type': 'application/json; charset=utf-8'}

    except Exception as e:
        logging.error(f"Ошибка: {traceback.format_exc()}")
        return '', 500

        
        
@app.route('/api/upload', methods=['POST'])
def upload_file():
    file_content = request.data.decode('utf-8')
    return 'File received', 200

if __name__ == '__main__':
    app.run(debug=True)


# -----------------------------------------------------РАБОТАЕТ-----------------------------------------------------------------
# from flask import Flask, request

# app = Flask(__name__)  

# @app.route('/api/upload', methods=['POST'])
# def upload_file():
#     # Получаем содержимое файла
#     file_content = request.data.decode('utf-8')
    
#     # Здесь можно обработать данные
#     print(file_content)  # Выводим в консоль

#     return 'File received', 200

# if __name__ == '__main__':  
#     app.run(debug=True)
# -----------------------------------------------------РАБОТАЕТ-----------------------------------------------------------------

# import pandas as pd
# import numpy as np
# from flask import Flask, request, jsonify
# from sklearn.linear_model import LogisticRegression
# from sklearn.model_selection import train_test_split
# import io

# # Установка опции Pandas для предотвращения предупреждений
# pd.set_option('future.no_silent_downcasting', True)

# class EEGProcessor:
#     def __init__(self):
#         self.model = None
#         self.n_features = None  # Изначально не задано

#     def preprocess_eeg_data(self, data):
#         df = pd.DataFrame(data)
#         df = df.replace('-', np.nan)
#         df = df.apply(pd.to_numeric, errors='coerce')
#         df.dropna(inplace=True)
#         return df.values

#     def set_n_features(self, n):
#         self.n_features = n

#     def extract_features(self, processed_data):
#         if self.n_features is not None and processed_data.shape[1] != self.n_features:
#             raise ValueError(f"Ожидается {self.n_features} признаков, но получено {processed_data.shape[1]}.")
#         return processed_data

#     def train_model(self, X_train, y_train):
#         self.model = LogisticRegression()
#         self.model.fit(X_train, y_train)

#     def predict(self, data):
#         processed_data = self.preprocess_eeg_data(data)
#         features = self.extract_features(processed_data)

#         print(f'Размерность данных для предсказания: {features.shape}')

#         if self.model is None:
#             raise ValueError("Модель не обучена. Пожалуйста, сначала обучите модель.")

#         prediction = self.model.predict(features)
#         return prediction[0]

# # Flask приложение
# app = Flask(__name__)
# eeg_processor = EEGProcessor()

# @app.route('/api/upload', methods=['POST'])
# def upload_file():
#     file_content = request.data.decode('utf-8')

#     print(file_content)

#     try:
#         file_content_io = io.StringIO(file_content)
#         df = pd.read_csv(file_content_io)
#         eeg_data = df.values

#         processed_data = eeg_processor.preprocess_eeg_data(eeg_data)

#         # Установим количество признаков на основе загруженных данных
#         eeg_processor.set_n_features(processed_data.shape[1])

#         # Если модель еще не обучена, обучим ее на загруженных данных
#         if eeg_processor.model is None:
#             # Генерируем случайные метки для обучения (в реальном случае нужно использовать реальные метки)
#             y_train = np.random.randint(0, 3, processed_data.shape[0])
#             eeg_processor.train_model(processed_data, y_train)

#         features = eeg_processor.extract_features(processed_data)
#         diagnosis = eeg_processor.predict(features)

#         diagnoses = {
#             0: "Нейротипичное состояние",
#             1: "Эпилепсия",
#             2: "Аутизм"
#         }

#         print(f'Предсказанный диагноз: {diagnoses[diagnosis]}')

#         return jsonify({
#             'status': 'success',
#             'diagnosis': diagnoses[diagnosis]
#         }), 200

#     except Exception as e:
#         print(f"Ошибка: {str(e)}")
#         return jsonify({
#             'status': 'error',
#             'message': str(e)
#         }), 500

# if __name__ == '__main__':
#     app.run(debug=True)

# -----------------------------------------------------РАБОТАЕТ-----------------------------------------------------------------


# -----------------------------------------------------ОБУЧАЕМ МОДЕЛЬ-----------------------------------------------------------------

# import numpy as np
# import pandas as pd
# import tensorflow as tf
# from keras.models import Model
# from keras.optimizers import Adam
# from sklearn.model_selection import train_test_split
# from sklearn.impute import SimpleImputer
# import matplotlib.pyplot as plt
# import seaborn as sns
# from sklearn.metrics import confusion_matrix, classification_report, roc_curve, auc

# class TCSNet(tf.keras.layers.Layer):
#     def __init__(self, num_channels):
#         super(TCSNet, self).__init__()
#         self.num_channels = num_channels

#     def call(self, x):
#         return x  # Заглушка

# class MNFSFeatureSelector:
#     def __init__(self, num_features):
#         self.num_features = num_features

#     def select_features(self, x):
#         return x  # Заглушка

# class HHNN(tf.keras.layers.Layer):
#     def __init__(self, num_features, num_classes):
#         super(HHNN, self).__init__()
#         self.dense1 = tf.keras.layers.Dense(64, activation='relu')
#         self.dense2 = tf.keras.layers.Dense(32, activation='relu')
#         self.output_layer = tf.keras.layers.Dense(num_classes, activation='softmax')

#     def call(self, x):
#         x = self.dense1(x)
#         x = self.dense2(x)
#         return self.output_layer(x)

# class RTNeuroDDSM:
#     def __init__(self, num_channels, num_features, num_classes):
#         self.num_channels = num_channels
#         self.num_features = num_features
#         self.num_classes = num_classes
#         self.tcsnet = TCSNet(num_channels)
#         self.feature_selector = MNFSFeatureSelector(num_features)
#         self.hhnn = HHNN(num_features, num_classes)
#         self.model = self.build_model()

#     def build_model(self):
#         inputs = tf.keras.Input(shape=(self.num_features,))
#         x = self.tcsnet(inputs)
#         x = self.feature_selector.select_features(x)
#         outputs = self.hhnn(x)
#         model = Model(inputs=inputs, outputs=outputs)
#         model.compile(
#             optimizer=Adam(learning_rate=0.001),
#             loss='categorical_crossentropy',
#             metrics=['accuracy']
#         )
#         return model

#     def train(self, X_train, y_train, epochs=50, batch_size=32, validation_split=0.2):
#         return self.model.fit(
#             X_train, y_train,
#             epochs=epochs,
#             batch_size=batch_size,
#             validation_split=validation_split
#         )

#     def predict(self, X_test):
#         return self.model.predict(X_test)

#     def evaluate(self, X_test, y_test):
#         return self.model.evaluate(X_test, y_test)
    
#     def save(self, filepath):
#         """Сохранение модели в указанное место."""
#         self.model.save(filepath)

#     def load(self, filepath):
#         """Загрузка модели из указанного места."""
#         self.model = tf.keras.models.load_model(filepath)
    
#     def plot_training_history(self, history):
#         """Визуализация истории обучения"""
#         plt.figure(figsize=(12, 4))
        
#         # Loss
#         plt.subplot(1, 2, 1)
#         plt.plot(history.history['loss'], label='Обучающая потеря')
#         plt.plot(history.history['val_loss'], label='Валидационная потеря')
#         plt.title('Динамика потерь')
#         plt.xlabel('Эпоха')
#         plt.ylabel('Потеря')
#         plt.legend()
        
#         # Accuracy
#         plt.subplot(1, 2, 2)
#         plt.plot(history.history['accuracy'], label='Точность обучения')
#         plt.plot(history.history['val_accuracy'], label='Валидационная точность')
#         plt.title('Динамика точности')
#         plt.xlabel('Эпоха')
#         plt.ylabel('Точность')
#         plt.legend()
        
#         plt.tight_layout()
#         plt.show()

#     def plot_confusion_matrix(self, X_test, y_test):
#         """Построение матрицы неточностей"""
#         y_pred = self.model.predict(X_test)
#         y_pred_classes = np.argmax(y_pred, axis=1)
#         y_test_classes = np.argmax(y_test, axis=1)
        
#         cm = confusion_matrix(y_test_classes, y_pred_classes)
#         plt.figure(figsize=(8, 6))
#         sns.heatmap(cm, annot=True, fmt='d', cmap='Blues', 
#                     xticklabels=['Нейротипичные', 'Эпилепсия', 'Аутизм'],
#                     yticklabels=['Нейротипичные', 'Эпилепсия', 'Аутизм'])
#         plt.title('Матрица неточностей')
#         plt.xlabel('Предсказанные классы')
#         plt.ylabel('Истинные классы')
#         plt.show()

#     def plot_roc_curves(self, X_test, y_test):
#         """Построение ROC-кривых"""
#         y_pred_proba = self.model.predict(X_test)
        
#         plt.figure(figsize=(10, 8))
        
#         # Вычисление ROC для каждого класса
#         for i in range(3):  # 3 класса
#             fpr, tpr, _ = roc_curve(y_test[:, i], y_pred_proba[:, i])
#             roc_auc = auc(fpr, tpr)
            
#             plt.plot(fpr, tpr, 
#                      label=f'ROC кривая класса {i} (AUC = {roc_auc:.2f})')
        
#         plt.plot([0, 1], [0, 1], 'k--')
#         plt.xlim([0.0, 1.0])
#         plt.ylim([0.0, 1.05])
#         plt.xlabel('Доля ложных положительных')
#         plt.ylabel('Доля истинных положительных')
#         plt.title('Характеристические ROC-кривые')
#         plt.legend(loc="lower right")
#         plt.show()
        

# def load_data(file_paths, max_rows=None):
#     data_list = []
#     labels_list = []
#     for label, file_path in enumerate(file_paths):
#         df = pd.read_csv(file_path, nrows=max_rows) if max_rows else pd.read_csv(file_path)
#         print(f"Loaded {file_path} with shape {df.shape} and dtypes:\n{df.dtypes}")  # Отладка: выводим форму и типы загруженного DataFrame
#         data_list.append(df)
#         labels_list.append(np.full(df.shape[0], label))
#     combined_data = pd.concat(data_list, ignore_index=True, join='outer')
#     # Удаляем нечисловые столбцы
#     combined_data = combined_data.select_dtypes(include=[np.number])  # Оставляем только числовые столбцы
#     # Импьютируем пропуски средними значениями
#     imputer = SimpleImputer(strategy='mean')
#     combined_data_imputed = imputer.fit_transform(combined_data)
#     y = np.concatenate(labels_list)
#     return combined_data_imputed, y

# def main():
#     # Укажите пути к вашим датасетам
#     file_paths = [
#         'C:/Users/Elena/Desktop/ПрогаДиплом/Датасеты/Schizophrenia_dataset.csv',  # Шизофрения
#         'C:/Users/Elena/Desktop/ПрогаДиплом/Датасеты/Epilepsy_dataset.csv',       # Эпилепсия
#         'C:/Users/Elena/Desktop/ПрогаДиплом/Датасеты/Autism_dataset.csv'           # Аутизм
#     ]
#     # Загрузка данных с ограничением на количество строк (например, 10000)
#     max_rows = 1000  # Установите значение в зависимости от доступной памяти
#     X, y = load_data(file_paths, max_rows=max_rows)
#     # Преобразование меток в категориальный формат
#     num_classes = 3  # Нейротипичные, эпилепсия, аутизм
#     y = tf.keras.utils.to_categorical(y, num_classes=num_classes)
    
#     # Разделение на обучающую и тестовую выборки
#     X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

#     # Инициализация и обучение модели
#     model = RTNeuroDDSM(num_channels=X.shape[1], num_features=X.shape[1], num_classes=num_classes)
    
#     # Изменяем форму данных для обучения модели (если необходимо)
#     model.train(X_train, y_train)
    
#     # ---------------------------+++++++++++++
#     # Обучение с сохранением истории
#     history = model.train(X_train, y_train)
    
#     # Сохранение модели 
#     model.save('C:/Users/Elena/Desktop/Diplom/trained_model.h5')

#     # Визуализация результатов
#     model.plot_training_history(history)
#     model.plot_confusion_matrix(X_test, y_test)
#     model.plot_roc_curves(X_test, y_test)

#     # Вывод подробного отчета о классификации
#     y_pred = model.predict(X_test)
#     y_pred_classes = np.argmax(y_pred, axis=1)
#     y_test_classes = np.argmax(y_test, axis=1)
    
#     print("\nОтчет о классификации:")
#     print(classification_report(y_test_classes, y_pred_classes, 
#                                 target_names=['Нейротипичные', 'Эпилепсия', 'Аутизм']))

# if __name__ == "__main__":
#     main()





# -----------------------------------------------------ОБУЧАЕМ МОДЕЛЬ-----------------------------------------------------------------
