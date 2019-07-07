using System;
using System.Runtime.Serialization;

namespace CourseWork
{
    [DataContract]
    public class SettingsClass
    {
        /// <summary>
        /// IP Raspberry Pi
        /// </summary>
        [DataMember]
        public string Ip { get; private set; }

        /// <summary>
        /// Задержка между автоматическими поворотами сервомотора
        /// </summary>
        [DataMember]
        public int Delay { get; private set; }

        /// <summary>
        /// Конечная позиция сервомотора
        /// </summary>
        [DataMember]
        public int FinalPosition { get; private set; }

        /// <summary>
        /// Конструктор класса SettingClass
        /// </summary>
        /// <remarks>
        /// Пытается инициировать свойства класса переданными значениями
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Can't parse Delay or Final Position to integer.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Delay was less than 0.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Final Position was less than 75 or more than 250.
        /// </exception>
        /// <param name="ip">IP Raspberry Pi</param>
        /// <param name="delay">Задержка между автоматическими поворотами сервомотора</param>
        /// <param name="finalPosition">Конечная позиция сервомотора</param>
        public SettingsClass(string ip, string delay, string finalPosition)
        {
            int intDelay, intFinalPosition;
            if (!(int.TryParse(delay, out intDelay) && int.TryParse(finalPosition, out intFinalPosition)))
                throw new ArgumentException("Can't parse Delay or Final Position to integer.");

            if (intDelay <= 0)
                throw new ArgumentException("Delay was less than 0.");

            if (intFinalPosition < 75 || intFinalPosition > 250)
                throw new ArgumentException("Final Position was less than 75 or more than 250.");

            Ip = ip;
            Delay = intDelay;
            FinalPosition = intFinalPosition;
        }

        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns>Экземпляр класса, приведенный к строке</returns>
        public override string ToString()
        {
            return $"{Ip} {Delay} {FinalPosition}";
        }
    }
}
