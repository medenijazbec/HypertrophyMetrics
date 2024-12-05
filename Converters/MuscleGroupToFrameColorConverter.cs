using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.Converters
{
    public class MuscleGroupToFrameColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string muscleGroup = value as string;
            if (string.IsNullOrEmpty(muscleGroup))
                return Color.FromHex("#3B3B3D"); // Privzeta temno siva

            switch (muscleGroup.ToLower())
            {
                case "chest":
                    return Color.FromHex("#8B0000"); // Dark Red za prsnične mišice
                case "biceps":
                    return Color.FromHex("#FF8C00"); // Dark Orange za bicepse
                case "triceps":
                    return Color.FromHex("#FFD700"); // Gold za tricepse
                case "quadriceps":
                    return Color.FromHex("#006400"); // Dark Green za kvadricepse
                case "hamstrings":
                    return Color.FromHex("#228B22"); // Forest Green za hamstrings
                case "calves":
                    return Color.FromHex("#008080"); // Teal za mečke
                case "back":
                    return Color.FromHex("#4B0082"); // Indigo za hrbet
                case "shoulders":
                    return Color.FromHex("#FF4500"); // OrangeRed za ramena
                case "abs":
                    return Color.FromHex("#1E90FF"); // Dodger Blue za trebušne mišice
                case "forearms":
                    return Color.FromHex("#2F4F4F"); // Dark Slate Gray za predlaktje
                case "glutes":
                    return Color.FromHex("#C71585"); // Medium Violet Red za gluteuse
                case "trapezius":
                    return Color.FromHex("#8B4513"); // Saddle Brown za trapezio
                case "deltoids":
                    return Color.FromHex("#FF1493"); // Deep Pink za deltoide
                // Dodajte več mišičnih skupin po potrebi
                default:
                    return Color.FromHex("#A9A9A9"); // Privzeta siva (Dark Gray)
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
