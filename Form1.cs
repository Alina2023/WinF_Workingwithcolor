using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsLab1
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> sourceImage;  // Глобальная переменная для хранения исходного изображения
        private Image<Bgr, byte> secondImage;
        private float[,] filterMatrix; // Матрица фильтра

        public Form1()
        {
            InitializeComponent();
            filterMatrix = new float[,]
              {
                 { 0, -1, 0 },
                 { -1, 5, -1 },
                 { 0, -1, 0 }
              }; // Стандартный фильтр (резкость)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Заполнение ComboBox данными
            comboBox1.Items.Add("Red");
            comboBox1.Items.Add("Green");
            comboBox1.Items.Add("Blue");

            // Установим по умолчанию выбранный элемент
            comboBox1.SelectedIndex = 0; // Это сделает так, что по умолчанию будет выбран первый канал

            // Добавляем элементы в comboBoxConvertToHSV
            comboBoxConvertToHSV.Items.Add("Hue");        // Оттенок
            comboBoxConvertToHSV.Items.Add("Saturation"); // Насыщенность
            comboBoxConvertToHSV.Items.Add("Value");      // Яркость

            // Установим первый элемент как выбранный по умолчанию
            comboBoxConvertToHSV.SelectedIndex = 0;
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            // Создаем диалоговое окно для выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Отображаем диалог и получаем результат
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)  // Если файл выбран
            {
                string fileName = openFileDialog.FileName;  // Получаем путь к выбранному файлу

                // Загружаем изображение
                sourceImage = new Image<Bgr, byte>(fileName);  // Создаем объект Image из выбранного файла

                // Получаем текущие размеры ImageBox1
                int width = imageBox1.Width;
                int height = imageBox1.Height;

                // Вычисляем новые размеры изображения, чтобы оно заполнило ImageBox1, сохраняя пропорции
                double ratio = Math.Max((double)width / sourceImage.Width, (double)height / sourceImage.Height);
                int newWidth = (int)(sourceImage.Width * ratio);
                int newHeight = (int)(sourceImage.Height * ratio);

                // Изменяем размер изображения, сохраняя пропорции
                Image<Bgr, byte> resizedImage = sourceImage.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

                // Обрезаем лишнюю часть изображения, если оно больше по размеру
                int xOffset = (resizedImage.Width - width) / 2;
                int yOffset = (resizedImage.Height - height) / 2;

                // Создаем изображение нужного размера
                Image<Bgr, byte> croppedImage = resizedImage.Copy(new System.Drawing.Rectangle(xOffset, yOffset, width, height));

                // Отображаем центрированное и обрезанное изображение в imageBox1
                imageBox1.Image = croppedImage;
            }
        }

        private void buttonProcessChannel_Click(object sender, EventArgs e)
        {
            // Получаем индекс выбранного канала из ComboBox
            int channelIndex = comboBox1.SelectedIndex;

            // Получаем соответствующий канал изображения
            var channels = sourceImage.Split();  // Разделяем изображение на каналы
            Image<Gray, byte> selectedChannel = channels[channelIndex];  // Выбираем нужный канал

            // Получаем размеры imageBox2
            int imageBox2Width = imageBox2.Width;
            int imageBox2Height = imageBox2.Height;

            // Рассчитываем масштаб, чтобы изображение заполнило imageBox2, возможно, с обрезкой
            double ratio = Math.Max((double)imageBox2Width / selectedChannel.Width, (double)imageBox2Height / selectedChannel.Height);
            int newWidth = (int)(selectedChannel.Width * ratio);
            int newHeight = (int)(selectedChannel.Height * ratio);

            // Изменяем размер изображения с сохранением пропорций
            Image<Gray, byte> resizedImage = selectedChannel.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

            // Создаем новое изображение для хранения обрезанного результата
            Image<Gray, byte> croppedImage = new Image<Gray, byte>(imageBox2Width, imageBox2Height);

            // Находим координаты обрезки, чтобы центрировать изображение в imageBox2
            int xOffset = (resizedImage.Width - imageBox2Width) / 2;
            int yOffset = (resizedImage.Height - imageBox2Height) / 2;

            // Копируем часть изображения, которая попадает в bounds imageBox2
            croppedImage = resizedImage.GetSubRect(new System.Drawing.Rectangle(xOffset, yOffset, imageBox2Width, imageBox2Height));

            // Отображаем результат в imageBox2
            imageBox2.Image = croppedImage;
        }
        private void buttonConvertToGrayscale_Click(object sender, EventArgs e)
        {
            if (sourceImage == null) // Проверяем, загружено ли изображение
            {
                MessageBox.Show("Сначала загрузите изображение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем новое "серое" изображение с теми же размерами, что и исходное
            Image<Gray, byte> grayImage = new Image<Gray, byte>(sourceImage.Size);

            // Заполняем серое изображение
            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    // Применяем формулу преобразования в серый цвет
                    byte grayValue = Convert.ToByte(
                        0.299 * sourceImage.Data[y, x, 2] + // Красный канал
                        0.587 * sourceImage.Data[y, x, 1] + // Зеленый канал
                        0.114 * sourceImage.Data[y, x, 0]  // Синий канал
                    );

                    grayImage.Data[y, x, 0] = grayValue; // Устанавливаем значение серого цвета
                }
            }

            // Получаем размеры imageBox2
            int imageBox2Width = imageBox2.Width;
            int imageBox2Height = imageBox2.Height;

            // Рассчитываем масштаб, чтобы изображение заполнило imageBox2, возможно, с обрезкой
            double ratio = Math.Max((double)imageBox2Width / grayImage.Width, (double)imageBox2Height / grayImage.Height);
            int newWidth = (int)(grayImage.Width * ratio);
            int newHeight = (int)(grayImage.Height * ratio);

            // Изменяем размер изображения с сохранением пропорций
            Image<Gray, byte> resizedImage = grayImage.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

            // Создаем новое изображение для хранения обрезанного результата
            Image<Gray, byte> croppedImage = new Image<Gray, byte>(imageBox2Width, imageBox2Height);

            // Находим координаты обрезки, чтобы центрировать изображение в imageBox2
            int xOffset = (resizedImage.Width - imageBox2Width) / 2;
            int yOffset = (resizedImage.Height - imageBox2Height) / 2;

            // Копируем часть изображения, которая попадает в bounds imageBox2
            croppedImage = resizedImage.GetSubRect(new System.Drawing.Rectangle(xOffset, yOffset, imageBox2Width, imageBox2Height));

            // Отображаем результат в imageBox2
            imageBox2.Image = croppedImage;
        }

        private void buttonConvertToSepia_Click(object sender, EventArgs e)
        {
            if (sourceImage == null) // Проверяем, загружено ли изображение
            {
                MessageBox.Show("Сначала загрузите изображение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем копию изображения для обработки
            Image<Bgr, byte> sepiaImage = sourceImage.Clone();

            // Применяем формулы для сепии
            for (int y = 0; y < sepiaImage.Height; y++)
            {
                for (int x = 0; x < sepiaImage.Width; x++)
                {
                    // Получаем текущие значения пикселя
                    byte originalBlue = sepiaImage.Data[y, x, 0];
                    byte originalGreen = sepiaImage.Data[y, x, 1];
                    byte originalRed = sepiaImage.Data[y, x, 2];

                    // Применяем формулы для цвета
                    byte newRed = Convert.ToByte(Math.Min(0.393 * originalRed + 0.769 * originalGreen + 0.189 * originalBlue, 255));
                    byte newGreen = Convert.ToByte(Math.Min(0.349 * originalRed + 0.686 * originalGreen + 0.168 * originalBlue, 255));
                    byte newBlue = Convert.ToByte(Math.Min(0.272 * originalRed + 0.534 * originalGreen + 0.131 * originalBlue, 255));

                    // Задаём новые значения цвета
                    sepiaImage.Data[y, x, 0] = newBlue;
                    sepiaImage.Data[y, x, 1] = newGreen;
                    sepiaImage.Data[y, x, 2] = newRed;
                }
            }

            // Получаем размеры imageBox2
            int imageBox2Width = imageBox2.Width;
            int imageBox2Height = imageBox2.Height;

            // Рассчитываем масштаб, чтобы изображение заполнило imageBox2, возможно, с обрезкой
            double ratio = Math.Max((double)imageBox2Width / sepiaImage.Width, (double)imageBox2Height / sepiaImage.Height);
            int newWidth = (int)(sepiaImage.Width * ratio);
            int newHeight = (int)(sepiaImage.Height * ratio);

            // Изменяем размер изображения с сохранением пропорций
            Image<Bgr, byte> resizedImage = sepiaImage.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

            // Создаем новое изображение для хранения обрезанного результата
            Image<Bgr, byte> croppedImage = new Image<Bgr, byte>(imageBox2Width, imageBox2Height);

            // Находим координаты обрезки, чтобы центрировать изображение в imageBox2
            int xOffset = (resizedImage.Width - imageBox2Width) / 2;
            int yOffset = (resizedImage.Height - imageBox2Height) / 2;

            // Копируем часть изображения, которая попадает в bounds imageBox2
            croppedImage = resizedImage.GetSubRect(new System.Drawing.Rectangle(xOffset, yOffset, imageBox2Width, imageBox2Height));

            // Отображаем результат в imageBox2
            imageBox2.Image = croppedImage;
        }
        private void ApplyBrightnessAndContrast(double brightness, double contrast)
        {
            if (sourceImage == null)
            {
                MessageBox.Show("Сначала загрузите изображение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем копию изображения для обработки
            Image<Bgr, byte> adjustedImage = sourceImage.Clone();

            for (int y = 0; y < adjustedImage.Height; y++)
            {
                for (int x = 0; x < adjustedImage.Width; x++)
                {
                    for (int c = 0; c < 3; c++) // Проходим по каналам (B, G, R)
                    {
                        double newColor = adjustedImage.Data[y, x, c]; // Исходное значение канала
                        newColor = newColor * contrast;                // Применяем контраст
                        newColor = newColor + brightness;              // Применяем яркость
                        newColor = Math.Min(255, Math.Max(0, newColor)); // Обрезаем значение в диапазоне [0, 255]
                        adjustedImage.Data[y, x, c] = (byte)newColor;
                    }
                }
            }

            // Получаем размеры imageBox2
            int imageBox2Width = imageBox2.Width;
            int imageBox2Height = imageBox2.Height;

            // Рассчитываем масштаб, чтобы изображение заполнило imageBox2, возможно, с обрезкой
            double ratio = Math.Max((double)imageBox2Width / adjustedImage.Width, (double)imageBox2Height / adjustedImage.Height);
            int newWidth = (int)(adjustedImage.Width * ratio);
            int newHeight = (int)(adjustedImage.Height * ratio);

            // Изменяем размер изображения с сохранением пропорций
            Image<Bgr, byte> resizedImage = adjustedImage.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

            // Создаем новое изображение для хранения обрезанного результата
            Image<Bgr, byte> croppedImage = new Image<Bgr, byte>(imageBox2Width, imageBox2Height);

            // Находим координаты обрезки, чтобы центрировать изображение в imageBox2
            int xOffset = (resizedImage.Width - imageBox2Width) / 2;
            int yOffset = (resizedImage.Height - imageBox2Height) / 2;

            // Копируем часть изображения, которая попадает в bounds imageBox2
            croppedImage = resizedImage.GetSubRect(new System.Drawing.Rectangle(xOffset, yOffset, imageBox2Width, imageBox2Height));

            // Отображаем результат в imageBox2
            imageBox2.Image = croppedImage;
        }
        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            double brightness = trackBarBrightness.Value; // Получаем значение яркости
            double contrast = trackBarContrast.Value / 50.0; // Нормализуем контраст (например, диапазон от 0 до 2)
            ApplyBrightnessAndContrast(brightness, contrast);
        }
        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            double brightness = trackBarBrightness.Value;
            double contrast = trackBarContrast.Value / 50.0;
            ApplyBrightnessAndContrast(brightness, contrast);
        }
        private void comboBoxConvertToHSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Настраиваем TrackBar в зависимости от выбранного параметра
            switch (comboBoxConvertToHSV.SelectedIndex)
            {
                case 0: // Hue
                    trackBar1.Minimum = -179;
                    trackBar1.Maximum = 179;
                    trackBar1.Value = 0;
                    break;
                case 1: // Saturation
                    trackBar1.Minimum = 0;
                    trackBar1.Maximum = 200; // 100% — оригинальная насыщенность, до 200% увеличения
                    trackBar1.Value = 100;
                    break;
                case 2: // Value
                    trackBar1.Minimum = 0;
                    trackBar1.Maximum = 200; // 100% — оригинальная яркость, до 200% увеличения
                    trackBar1.Value = 100;
                    break;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (sourceImage == null)
            {
                MessageBox.Show("Сначала загрузите изображение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем изображение в HSV
            Image<Hsv, byte> hsvImage = sourceImage.Convert<Hsv, byte>();

            // Получаем выбранный параметр
            int selectedIndex = comboBoxConvertToHSV.SelectedIndex;

            // Применяем изменения к каждому пикселю
            for (int y = 0; y < hsvImage.Height; y++)
            {
                for (int x = 0; x < hsvImage.Width; x++)
                {
                    Hsv pixel = hsvImage[y, x];

                    switch (selectedIndex)
                    {
                        case 0: // Hue
                            pixel.Hue = (pixel.Hue + trackBar1.Value) % 180; // Hue изменяется в диапазоне [0, 179]
                            break;
                        case 1: // Saturation
                            pixel.Satuation = Math.Min(255, pixel.Satuation * (trackBar1.Value / 100.0)); // Масштабируем насыщенность
                            break;
                        case 2: // Value
                            pixel.Value = Math.Min(255, pixel.Value * (trackBar1.Value / 100.0)); // Масштабируем яркость
                            break;
                    }

                    hsvImage[y, x] = pixel;
                }
            }

            // Преобразуем обратно в формат BGR
            Image<Bgr, byte> resultImage = hsvImage.Convert<Bgr, byte>();

            // Получаем размеры imageBox2
            int imageBox2Width = imageBox2.Width;
            int imageBox2Height = imageBox2.Height;

            // Рассчитываем масштаб, чтобы изображение заполнило imageBox2, возможно, с обрезкой
            double ratio = Math.Max((double)imageBox2Width / resultImage.Width, (double)imageBox2Height / resultImage.Height);
            int newWidth = (int)(resultImage.Width * ratio);
            int newHeight = (int)(resultImage.Height * ratio);

            // Изменяем размер изображения с сохранением пропорций
            Image<Bgr, byte> resizedImage = resultImage.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

            // Создаем новое изображение для хранения обрезанного результата
            Image<Bgr, byte> croppedImage = new Image<Bgr, byte>(imageBox2Width, imageBox2Height);

            // Находим координаты обрезки, чтобы центрировать изображение в imageBox2
            int xOffset = (resizedImage.Width - imageBox2Width) / 2;
            int yOffset = (resizedImage.Height - imageBox2Height) / 2;

            // Копируем часть изображения, которая попадает в bounds imageBox2
            croppedImage = resizedImage.GetSubRect(new System.Drawing.Rectangle(xOffset, yOffset, imageBox2Width, imageBox2Height));

            // Отображаем результат в imageBox2
            imageBox2.Image = croppedImage;
        }
        private void ApplyMedianBlur()
        {
            if (sourceImage == null) // Проверяем, загружено ли изображение
            {
                MessageBox.Show("Сначала загрузите изображение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Применяем медианное размытие
            Image<Bgr, byte> blurredImage = sourceImage.Clone();
            CvInvoke.MedianBlur(blurredImage, blurredImage, 5); // 5 - это размер ядра (можно менять по желанию)

            // Получаем размеры imageBox2
            int imageBox2Width = imageBox2.Width;
            int imageBox2Height = imageBox2.Height;

            // Рассчитываем масштаб, чтобы изображение заполнило imageBox2, возможно, с обрезкой
            double ratio = Math.Max((double)imageBox2Width / blurredImage.Width, (double)imageBox2Height / blurredImage.Height);
            int newWidth = (int)(blurredImage.Width * ratio);
            int newHeight = (int)(blurredImage.Height * ratio);

            // Изменяем размер изображения с сохранением пропорций
            Image<Bgr, byte> resizedImage = blurredImage.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

            // Создаем новое изображение для хранения обрезанного результата
            Image<Bgr, byte> croppedImage = new Image<Bgr, byte>(imageBox2Width, imageBox2Height);

            // Находим координаты обрезки, чтобы центрировать изображение в imageBox2
            int xOffset = (resizedImage.Width - imageBox2Width) / 2;
            int yOffset = (resizedImage.Height - imageBox2Height) / 2;

            // Копируем часть изображения, которая попадает в bounds imageBox2
            croppedImage = resizedImage.GetSubRect(new System.Drawing.Rectangle(xOffset, yOffset, imageBox2Width, imageBox2Height));

            // Отображаем результат в imageBox2
            imageBox2.Image = croppedImage;
        }

        private void buttonMedianBlur_Click(object sender, EventArgs e)
        {
            ApplyMedianBlur(); // Вызов метода для применения медианного размытия
        }
        private void buttonLogicalNot_Click_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image == null)
            {
                MessageBox.Show("Сначала загрузите изображение в imageBox1!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем изображение из imageBox1
            var inputImage = (imageBox1.Image as Emgu.CV.Image<Bgr, byte>);
            var notImage = inputImage.Not();

            // Выводим результат в imageBox2
            imageBox2.Image = notImage;
        }
        private void buttonLogicalXor_Click_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image == null || imageBox2.Image == null)
            {
                MessageBox.Show("Сначала загрузите изображения в imageBox1 и imageBox2!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем изображения из imageBox1 и imageBox2
            var image1 = (imageBox1.Image as Emgu.CV.Image<Bgr, byte>);
            var image2 = (imageBox2.Image as Emgu.CV.Image<Bgr, byte>);

            // Убедимся, что размеры совпадают
            if (image1.Size != image2.Size)
            {
                MessageBox.Show("Размеры изображений не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Применяем XOR
            var xorImage = image1.Xor(image2);

            // Выводим результат в imageBox2
            imageBox2.Image = xorImage;
        }
        private Image<Bgr, byte> PadImageToSize(Image<Bgr, byte> image, Size targetSize)
        {
            // Создаём новое изображение с целевым размером (по умолчанию чёрный фон)
            Image<Bgr, byte> paddedImage = new Image<Bgr, byte>(targetSize);

            // Вычисляем начальные координаты для центрирования
            int xOffset = (targetSize.Width - image.Width) / 2;
            int yOffset = (targetSize.Height - image.Height) / 2;

            // Вставляем изображение в центр новой пустой картинки
            paddedImage.ROI = new Rectangle(xOffset, yOffset, image.Width, image.Height);
            image.CopyTo(paddedImage);
            paddedImage.ROI = Rectangle.Empty;

            return paddedImage;
        }
        private void buttonLogicalAnd_Click_1(object sender, EventArgs e)
        {
            if (sourceImage == null || secondImage == null)
            {
                MessageBox.Show("Сначала загрузите оба изображения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Приведение к одинаковому размеру
            if (sourceImage.Size != secondImage.Size)
            {
                Size maxSize = new Size(
                    Math.Max(sourceImage.Width, secondImage.Width),
                    Math.Max(sourceImage.Height, secondImage.Height)
                );

                sourceImage = PadImageToSize(sourceImage, maxSize);
                secondImage = PadImageToSize(secondImage, maxSize);
            }

            // Выполняем AND операцию
            Image<Bgr, byte> andImage = sourceImage.And(secondImage);

            // Получаем размеры imageBox2
            int imageBox2Width = imageBox2.Width;
            int imageBox2Height = imageBox2.Height;

            // Рассчитываем масштаб, чтобы изображение заполнило imageBox2, возможно, с обрезкой
            double ratio = Math.Max((double)imageBox2Width / andImage.Width, (double)imageBox2Height / andImage.Height);
            int newWidth = (int)(andImage.Width * ratio);
            int newHeight = (int)(andImage.Height * ratio);

            // Изменяем размер изображения с сохранением пропорций
            Image<Bgr, byte> resizedImage = andImage.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

            // Создаем новое изображение для хранения обрезанного результата
            Image<Bgr, byte> croppedImage = new Image<Bgr, byte>(imageBox2Width, imageBox2Height);

            // Находим координаты обрезки, чтобы центрировать изображение в imageBox2
            int xOffset = (resizedImage.Width - imageBox2Width) / 2;
            int yOffset = (resizedImage.Height - imageBox2Height) / 2;

            // Копируем часть изображения, которая попадает в bounds imageBox2
            croppedImage = resizedImage.GetSubRect(new System.Drawing.Rectangle(xOffset, yOffset, imageBox2Width, imageBox2Height));

            // Отображаем результат в imageBox2
            imageBox2.Image = croppedImage;
        }
        private void buttonLogicalNot_Click(object sender, EventArgs e)
        {
            if (sourceImage == null)
            {
                MessageBox.Show("Сначала загрузите изображение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем изображение из imageBox1 обратно в формат Image<Bgr, byte>
            Image<Bgr, byte> inputImage = imageBox1.Image as Image<Bgr, byte>;
            if (inputImage == null)
            {
                MessageBox.Show("Изображение в imageBox1 имеет неверный формат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Применяем логическое отрицание (инверсия)
            Image<Bgr, byte> invertedImage = inputImage.Not();

            // Отображаем результат в imageBox2
            imageBox2.Image = invertedImage;
        }
        private void buttonLogicalXor_Click(object sender, EventArgs e)
        {
            if (sourceImage == null || secondImage == null)
            {
                MessageBox.Show("Сначала загрузите оба изображения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Приведение изображений к одинаковому размеру
            if (sourceImage.Size != secondImage.Size)
            {
                Size maxSize = new Size(
                    Math.Max(sourceImage.Width, secondImage.Width),
                    Math.Max(sourceImage.Height, secondImage.Height)
                );

                sourceImage = PadImageToSize(sourceImage, maxSize);
                secondImage = PadImageToSize(secondImage, maxSize);
            }

            // Создаем копию исходного изображения для хранения результата
            Image<Bgr, byte> xorImage = sourceImage.Clone();

            // Выполняем побитовую операцию XOR для каждого канала (B, G, R)
            for (int y = 0; y < xorImage.Height; y++)
            {
                for (int x = 0; x < xorImage.Width; x++)
                {
                    // Получаем значения пикселей для обоих изображений
                    byte blueSource = sourceImage.Data[y, x, 0];
                    byte greenSource = sourceImage.Data[y, x, 1];
                    byte redSource = sourceImage.Data[y, x, 2];

                    byte blueSecond = secondImage.Data[y, x, 0];
                    byte greenSecond = secondImage.Data[y, x, 1];
                    byte redSecond = secondImage.Data[y, x, 2];

                    // Выполняем операцию XOR для каждого канала
                    byte blueResult = (byte)(blueSource ^ blueSecond);
                    byte greenResult = (byte)(greenSource ^ greenSecond);
                    byte redResult = (byte)(redSource ^ redSecond);

                    // Присваиваем результат операции XOR в новое изображение
                    xorImage.Data[y, x, 0] = blueResult;
                    xorImage.Data[y, x, 1] = greenResult;
                    xorImage.Data[y, x, 2] = redResult;
                }
            }

            // Получаем размеры imageBox2
            int imageBox2Width = imageBox2.Width;
            int imageBox2Height = imageBox2.Height;

            // Рассчитываем масштаб, чтобы изображение заполнило imageBox2, возможно, с обрезкой
            double ratio = Math.Max((double)imageBox2Width / xorImage.Width, (double)imageBox2Height / xorImage.Height);
            int newWidth = (int)(xorImage.Width * ratio);
            int newHeight = (int)(xorImage.Height * ratio);

            // Изменяем размер изображения с сохранением пропорций
            Image<Bgr, byte> resizedImage = xorImage.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

            // Создаем новое изображение для хранения обрезанного результата
            Image<Bgr, byte> croppedImage = new Image<Bgr, byte>(imageBox2Width, imageBox2Height);

            // Находим координаты обрезки, чтобы центрировать изображение в imageBox2
            int xOffset = (resizedImage.Width - imageBox2Width) / 2;
            int yOffset = (resizedImage.Height - imageBox2Height) / 2;

            // Копируем часть изображения, которая попадает в bounds imageBox2
            croppedImage = resizedImage.GetSubRect(new System.Drawing.Rectangle(xOffset, yOffset, imageBox2Width, imageBox2Height));

            // Отображаем результат в imageBox2
            imageBox2.Image = croppedImage;
        }
        private void buttonLoadSecondImage_Click_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Загружаем второе изображение
                secondImage = new Image<Bgr, byte>(openFileDialog.FileName);

                // Получаем текущие размеры ImageBox2
                int width = imageBox2.Width;
                int height = imageBox2.Height;

                // Вычисляем новые размеры изображения, чтобы оно заполнило ImageBox2, сохраняя пропорции
                double ratio = Math.Max((double)width / secondImage.Width, (double)height / secondImage.Height);
                int newWidth = (int)(secondImage.Width * ratio);
                int newHeight = (int)(secondImage.Height * ratio);

                // Изменяем размер изображения, сохраняя пропорции
                Image<Bgr, byte> resizedImage = secondImage.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

                // Обрезаем лишнюю часть изображения, если оно больше по размеру
                int xOffset = (resizedImage.Width - width) / 2;
                int yOffset = (resizedImage.Height - height) / 2;

                // Создаем изображение нужного размера
                Image<Bgr, byte> croppedImage = resizedImage.Copy(new System.Drawing.Rectangle(xOffset, yOffset, width, height));

                // Отображаем центрированное и обрезанное изображение в imageBox2
                imageBox2.Image = croppedImage;
            }
        }

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                // Преобразование текста из textbox1 в матрицу фильтра
                string input = textBox1.Text;
                float[,] matrix = ParseFilterMatrix(input);
                if (matrix.GetLength(0) != matrix.GetLength(1))
                {
                    MessageBox.Show("Матрица фильтра должна быть квадратной!");
                    return;
                }

                filterMatrix = matrix; // Сохраняем новую матрицу
                if (sourceImage == null)
                {
                    MessageBox.Show("Исходное изображение не загружено!");
                    return;
                }

                // Применяем фильтр к изображению
                secondImage = ApplyFilter(sourceImage, filterMatrix);

                // Получаем размеры imageBox2
                int imageBox2Width = imageBox2.Width;
                int imageBox2Height = imageBox2.Height;

                // Рассчитываем масштаб, чтобы изображение заполнило imageBox2, возможно, с обрезкой
                double ratio = Math.Max((double)imageBox2Width / secondImage.Width, (double)imageBox2Height / secondImage.Height);
                int newWidth = (int)(secondImage.Width * ratio);
                int newHeight = (int)(secondImage.Height * ratio);

                // Изменяем размер изображения с сохранением пропорций
                Image<Bgr, byte> resizedImage = secondImage.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);

                // Создаем новое изображение для хранения обрезанного результата
                Image<Bgr, byte> croppedImage = new Image<Bgr, byte>(imageBox2Width, imageBox2Height);

                // Находим координаты обрезки, чтобы центрировать изображение в imageBox2
                int xOffset = (resizedImage.Width - imageBox2Width) / 2;
                int yOffset = (resizedImage.Height - imageBox2Height) / 2;

                // Копируем часть изображения, которая попадает в bounds imageBox2
                croppedImage = resizedImage.GetSubRect(new System.Drawing.Rectangle(xOffset, yOffset, imageBox2Width, imageBox2Height));

                // Отображаем результат в imageBox2
                imageBox2.Image = croppedImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private float[,] ParseFilterMatrix(string input)
        {
            // Парсинг матрицы из строки
            var rows = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int size = rows.Length;
            var matrix = new float[size, size];

            for (int i = 0; i < size; i++)
            {
                var values = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length != size)
                    throw new Exception("Матрица должна быть квадратной!");

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = float.Parse(values[j]);
                }
            }

            return matrix;
        }

        private Image<Bgr, byte> ApplyFilter(Image<Bgr, byte> image, float[,] matrix)
        {
            if (image == null) throw new Exception("Изображение не загружено!");

            // Преобразуем матрицу фильтра в объект Emgu CV
            var kernel = new Matrix<float>(matrix);

            // Создаём выходное изображение
            Image<Bgr, byte> result = image.CopyBlank();

            // Применяем фильтр
            CvInvoke.Filter2D(image, result, kernel, new System.Drawing.Point(-1, -1));

            return result;
        }
    }
}