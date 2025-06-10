

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


# from flask import Flask, request, jsonify
# import tensorflow as tf
# from keras.utils import custom_object_scope
# import pandas as pd
# import numpy as np
# from sklearn.impute import SimpleImputer
# import logging
# from keras.models import Model, Sequential
# import traceback
# import chardet
# import json

# # Настройка логирования
# logging.basicConfig(level=logging.INFO)

# class HHNN(tf.keras.Model):
#     def __init__(self, num_features=None, num_classes=3, **kwargs):
#         super(HHNN, self).__init__(**kwargs)
        
#         self.num_features = num_features
#         self.num_classes = num_classes
        
#         # Создаем слои с проверкой num_features
#         if num_features is not None and num_features > 0:
#             self.dense1 = tf.keras.layers.Dense(min(64, max(16, num_features // 2)), activation='relu', input_shape=(num_features,))
#             self.dense2 = tf.keras.layers.Dense(min(32, max(8, num_features // 4)), activation='relu')
#             self.output_layer = tf.keras.layers.Dense(num_classes, activation='softmax')
#         else:
#             raise ValueError("Количество признаков должно быть положительным")

#     def call(self, inputs):
#         x = self.dense1(inputs)
#         x = self.dense2(x)
#         return self.output_layer(x)

#     def build(self, input_shape):
#         super().build(input_shape)

# def create_adaptive_model(num_features):
#     """
#     Создание адаптивной модели с динамическим количеством входных признаков
#     """
#     model = HHNN(num_features=num_features)
    
#     # Компиляция модели
#     model.compile(
#         optimizer='adam',
#         loss='categorical_crossentropy',
#         metrics=['accuracy']
#     )
    
#     return model

# def detect_encoding(file_content):
#     """
#     Определение кодировки файла
#     """
#     try:
#         result = chardet.detect(file_content.encode())
#         return result['encoding']
#     except Exception as e:
#         logging.error(f"Ошибка определения кодировки: {e}")
#         return 'utf-8'  # Кодировка по умолчанию

# def preprocess_data(file_content):
#     logging.info("Начало предобработки данных")
    
#     try:
#         # Парсим JSON-данные
#         data = json.loads(file_content)
        
#         # Преобразуем JSON в DataFrame
#         df = pd.DataFrame(data)
        
#         # Преобразуем все столбцы в числовой формат
#         for col in df.columns:
#             df[col] = pd.to_numeric(df[col], errors='coerce')
        
#         # Проверяем, есть ли числовые столбцы
#         numeric_df = df.select_dtypes(include=[np.number])
        
#         if numeric_df.empty:
#             raise ValueError("Нет числовых столбцов")
        
#         # Обработка пропусков
#         imputer = SimpleImputer(strategy='mean')
#         processed_data = imputer.fit_transform(numeric_df)
        
#         logging.info(f"Предобработка успешна. Размер данных: {processed_data.shape}")
        
#         return processed_data
    
#     except Exception as e:
#         logging.error(f"Ошибка предобработки: {str(e)}")
#         logging.error(f"Трассировка: {traceback.format_exc()}")
#         raise



# # Инициализация приложения Flask
# app = Flask(__name__)

# @app.route('/api/predict', methods=['POST'])
# def predict_disease():
#     try:
#         file_content = request.data.decode('utf-8')
        
#         try:
#             processed_data = preprocess_data(file_content)
#         except Exception as preprocess_error:
#             logging.error(f"Ошибка предобработки: {str(preprocess_error)}")
#             return jsonify({'error': 'Не удалось обработать входные данные'}), 400
        
#         if processed_data.shape[0] == 0 or processed_data.shape[1] == 0:
#             return jsonify({'error': 'Нет данных для предсказания'}), 400
        
#         num_features = processed_data.shape[1]
#         model = create_adaptive_model(num_features)

#         # Здесь можно обучить модель на ваших данных, если нужно
#         # model.fit(...)

#         # Предсказания
#         predictions = model.predict(processed_data)
#         predicted_classes = np.argmax(predictions, axis=1)
        
#         class_names = ['Нейротипичные', 'Эпилепсия', 'Аутизм']
        
#         # Определение наиболее частого класса
#         unique, counts = np.unique(predicted_classes, return_counts=True)
#         majority_class_index = unique[np.argmax(counts)]
#         majority_class_name = class_names[majority_class_index]

#         # Средняя вероятность для этого класса
#         majority_probs = predictions[:, majority_class_index]
#         avg_probability = float(np.mean(majority_probs)) * 100  # в процентах

#         logging.info(f"Финальный диагноз: {majority_class_name} ({avg_probability:.2f}%)")

#         return jsonify({
#             'diagnosis': majority_class_name,
#             'confidence_percent': round(avg_probability, 2)
#         }), 200, {'Content-Type': 'application/json; charset=utf-8'}

#     except Exception as e:
#         logging.error(f"Ошибка: {traceback.format_exc()}")
#         return '', 500

        
        
# @app.route('/api/upload', methods=['POST'])
# def upload_file():
#     file_content = request.data.decode('utf-8')
#     return 'File received', 200

# if __name__ == '__main__':
#     app.run(debug=True)


# -----------------------------------------------------РАБОТАЕТ-----------------------------------------------------------------
from flask import Flask, request, jsonify
import numpy as np
import logging
import traceback
from keras.models import load_model

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
        
        # Загрузка ранее обученной модели
        model = load_model('C:/Users/Elena/Desktop/Diplom/trained_model.h5')

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






# -----------------------------------------------------ОБУЧАЕМ МОДЕЛЬ-----------------------------------------------------------------
