using System.Windows.Forms;

namespace MathStatRGR.Utils
{
    /// <summary>
    /// Вспомогательный класс для чтения данных из файлов CSV или TXT.
    /// </summary>
    public static class FileDataReader
    {
        /// <summary>
        /// Отображает диалоговое окно для выбора файла CSV или TXT и возвращает путь к выбранному файлу.
        /// </summary>
        /// <returns>Путь к выбранному файлу или null, если пользователь отменил выбор.</returns>
        public static string GetCsvOrTxtFilePath()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Настраиваем фильтр для файлов CSV и TXT
                openFileDialog.Filter = "Файлы данных (*.csv;*.txt)|*.csv;*.txt|CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл данных";
                openFileDialog.FilterIndex = 1; // По умолчанию выбран фильтр "*.csv;*.txt"
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.RestoreDirectory = true; // Восстанавливать последнюю директорию

                // Показываем диалог и возвращаем результат
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
                else
                {
                    return null; // Пользователь нажал "Отмена"
                }
            }
        }
    }
}