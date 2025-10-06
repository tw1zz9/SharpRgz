using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpRgz;
using System;
using System.IO;
using Xunit;

namespace TestRgz
{
    [TestClass]
    public class AudioAndVideoTests
    {
        [Fact]
        public void CreateDevice_DefaultConstructor_SetsDefaultValues()
        {
            // Act
            var device = new AudioAndVideo();

            // Assert
            Xunit.Assert.Equal("Unknown", device.Manufacturer);
            Xunit.Assert.Equal(300, device.Price); 
        }

        [Fact]
        public void CreateDevice_WithParameters_SetsCorrectValues()
        {
            var device = new AudioAndVideo("sony", 5000);

            Xunit.Assert.Equal("sony", device.Manufacturer);
            Xunit.Assert.Equal(5000, device.Price);
        }

        [Fact]
        public void SetManufacturer_Lowercase_ConvertsToProperCase()
        {
            var device = new AudioAndVideo();

            device.Manufacturer = "samsung";

            Xunit.Assert.Equal("samsung", device.Manufacturer);
        }

        [Fact]
        public void SetManufacturer_Uppercase_ConvertsToProperCase()
        {
            var device = new AudioAndVideo();

            device.Manufacturer = "LG";

            Xunit.Assert.Equal("LG", device.Manufacturer);
        }

        [Fact]
        public void SetManufacturer_EmptyString_SetsToUnknown()
        {
            // Arrange
            var device = new AudioAndVideo();

            // Act
            device.Manufacturer = "";

            // Assert
            Xunit.Assert.Equal("Unknown", device.Manufacturer);
        }

        [Fact]
        public void SetManufacturer_WithNumbers_AcceptsAlphanumeric()
        {
            var device = new AudioAndVideo();

            device.Manufacturer = "philips123";

            Xunit.Assert.Equal("philips123", device.Manufacturer);
        }

        [Fact]
        public void SetPrice_TooLow_SetsToMinimum()
        {
            // Arrange
            var device = new AudioAndVideo();

            // Act
            device.Price = 100;

            // Assert
            Xunit.Assert.Equal(300, device.Price);
        }

        [Fact]
        public void SetPrice_TooHigh_SetsToMinimum()
        {
            // Arrange
            var device = new AudioAndVideo();

            // Act
            device.Price = 8000000;

            // Assert
            Xunit.Assert.Equal(300, device.Price);
        }

        [Fact]
        public void SetPrice_ValidValue_KeepsValue()
        {
            // Arrange
            var device = new AudioAndVideo();

            // Act
            device.Price = 5000;

            // Assert
            Xunit.Assert.Equal(5000, device.Price);
        }

        [Fact]
        public void Assign_CopyFromOtherDevice_CopiesValues()
        {
            // Arrange
            var device1 = new AudioAndVideo("sony", 5000);
            var device2 = new AudioAndVideo();

            // Act
            device2.Assign(device1);

            // Assert
            Xunit.Assert.Equal(device1.Manufacturer, device2.Manufacturer); 
            Xunit.Assert.Equal(5000, device2.Price);
        }

        [Fact]
        public void ToString_ContainsDeviceInfo()
        {
            var device = new AudioAndVideo();
            device.Manufacturer = "samsung"; 
            device.Price = 7000;

            var result = device.ToString();

            Xunit.Assert.Contains("samsung", result); 
            Xunit.Assert.Contains("7000", result);
            Xunit.Assert.Contains("Manufacturer", result);
            Xunit.Assert.Contains("Price", result);
        }

        [Fact]
        public void CopyConstructor_CreatesCopy()
        {
            // Arrange
            var original = new AudioAndVideo("lg", 4000);

            // Act
            var copy = new AudioAndVideo(original);

            // Assert
            Xunit.Assert.Equal(original.Manufacturer, copy.Manufacturer);
            Xunit.Assert.Equal(original.Price, copy.Price);
        }
    }





    [TestClass]
    public class TvSetTests
    {
        [Fact]
        public void CreateTvSet_DefaultConstructor_SetsDefaultValues()
        {
            var tv = new TvSet();

            Xunit.Assert.Equal("Unknown", tv.Manufacturer);
            Xunit.Assert.Equal(7000, tv.Price);
            Xunit.Assert.Equal(50, tv.Frequency);
            Xunit.Assert.Equal(24, tv.DiagonalSize);
        }

        [Fact]
        public void CreateTvSet_WithParameters_SetsCorrectValues()
        {
            var tv = new TvSet("samsung", 15000, 100, 32);

            Xunit.Assert.Equal("samsung", tv.Manufacturer);
            Xunit.Assert.Equal(15000, tv.Price);
            Xunit.Assert.Equal(100, tv.Frequency);
            Xunit.Assert.Equal(32, tv.DiagonalSize);
        }

        [Fact]
        public void SetFrequency_TooLow_SetsToMinimum()
        {
            var tv = new TvSet();

            tv.Frequency = 30;

            Xunit.Assert.Equal(50, tv.Frequency);
        }

        [Fact]
        public void SetFrequency_TooHigh_SetsToMinimum()
        {
            var tv = new TvSet();

            tv.Frequency = 400;

            Xunit.Assert.Equal(50, tv.Frequency);
        }

        [Fact]
        public void SetFrequency_ValidValue_KeepsValue()
        {
            var tv = new TvSet();

            tv.Frequency = 120;

            Xunit.Assert.Equal(120, tv.Frequency);
        }

        [Fact]
        public void SetDiagonalSize_TooSmall_SetsToMinimum()
        {
            var tv = new TvSet();

            tv.DiagonalSize = 20;

            Xunit.Assert.Equal(24, tv.DiagonalSize);
        }

        [Fact]
        public void SetDiagonalSize_TooLarge_SetsToMinimum()
        {
            var tv = new TvSet();

            tv.DiagonalSize = 120;

            Xunit.Assert.Equal(24, tv.DiagonalSize);
        }

        [Fact]
        public void SetDiagonalSize_ValidValue_KeepsValue()
        {
            var tv = new TvSet();

            tv.DiagonalSize = 55;

            Xunit.Assert.Equal(55, tv.DiagonalSize);
        }

        [Fact]
        public void Assign_CopyFromOtherTv_CopiesValues()
        {
            var tv1 = new TvSet("lg", 12000, 75, 43);
            var tv2 = new TvSet();

            tv2.Assign(tv1);

            Xunit.Assert.Equal(tv1.Manufacturer, tv2.Manufacturer);
            Xunit.Assert.Equal(tv1.Price, tv2.Price);
            Xunit.Assert.Equal(tv1.Frequency, tv2.Frequency);
            Xunit.Assert.Equal(tv1.DiagonalSize, tv2.DiagonalSize);
        }

        [Fact]
        public void ToString_ContainsTvInfo()
        {
            var tv = new TvSet();
            tv.Manufacturer = "Sony";
            tv.Price = 25000;
            tv.Frequency = 120;
            tv.DiagonalSize = 55;

            var result = tv.ToString();

            Xunit.Assert.Contains("Sony", result);
            Xunit.Assert.Contains("25000", result);
            Xunit.Assert.Contains("120", result);
            Xunit.Assert.Contains("55", result);
            Xunit.Assert.Contains("Frequency", result);
            Xunit.Assert.Contains("Diagonal size", result);
        }

        [Fact]
        public void CopyConstructor_CreatesCopy()
        {
            var original = new TvSet("philips", 18000, 100, 65);

            var copy = new TvSet(original);

            Xunit.Assert.Equal(original.Manufacturer, copy.Manufacturer);
            Xunit.Assert.Equal(original.Price, copy.Price);
            Xunit.Assert.Equal(original.Frequency, copy.Frequency);
            Xunit.Assert.Equal(original.DiagonalSize, copy.DiagonalSize);
        }
    }





    [TestClass]
    public class RadioTests
    {
        [Fact]
        public void CreateRadio_DefaultConstructor_SetsDefaultValues()
        {
            var radio = new Radio();

            Xunit.Assert.Equal("Unknown", radio.Manufacturer);
            Xunit.Assert.Equal(300, radio.Price);
            Xunit.Assert.Equal(0.0, radio.TransmitterPower);
            Xunit.Assert.Equal(0, radio.HasBluetooth);
        }

        [Fact]
        public void CreateRadio_WithParameters_SetsCorrectValues()
        {
            var radio = new Radio("sony", 5000, 5.5, 1);

            Xunit.Assert.Equal("sony", radio.Manufacturer);
            Xunit.Assert.Equal(5000, radio.Price);
            Xunit.Assert.Equal(5.5, radio.TransmitterPower);
            Xunit.Assert.Equal(1, radio.HasBluetooth);
        }

        [Fact]
        public void SetTransmitterPower_TooLow_SetsToDefault()
        {
            var radio = new Radio();

            radio.TransmitterPower = -10;

            Xunit.Assert.Equal(0.0, radio.TransmitterPower);
        }

        [Fact]
        public void SetTransmitterPower_TooHigh_SetsToDefault()
        {
            var radio = new Radio();

            radio.TransmitterPower = 250;

            Xunit.Assert.Equal(0.0, radio.TransmitterPower);
        }

        [Fact]
        public void SetTransmitterPower_ValidValue_KeepsValue()
        {
            var radio = new Radio();

            radio.TransmitterPower = 10.5;

            Xunit.Assert.Equal(10.5, radio.TransmitterPower);
        }

        [Fact]
        public void SetHasBluetooth_InvalidValue_SetsToZero()
        {
            var radio = new Radio();

            radio.HasBluetooth = 5;

            Xunit.Assert.Equal(0, radio.HasBluetooth);
        }

        [Fact]
        public void SetHasBluetooth_ValidZero_KeepsValue()
        {
            var radio = new Radio();

            radio.HasBluetooth = 0;

            Xunit.Assert.Equal(0, radio.HasBluetooth);
        }

        [Fact]
        public void SetHasBluetooth_ValidOne_KeepsValue()
        {
            var radio = new Radio();

            radio.HasBluetooth = 1;

            Xunit.Assert.Equal(1, radio.HasBluetooth);
        }

        [Fact]
        public void Assign_CopyFromOtherRadio_CopiesValues()
        {
            var radio1 = new Radio("philips", 3000, 7.5, 1);
            var radio2 = new Radio();

            radio2.Assign(radio1);

            Xunit.Assert.Equal(radio1.Manufacturer, radio2.Manufacturer);
            Xunit.Assert.Equal(radio1.Price, radio2.Price);
            Xunit.Assert.Equal(radio1.TransmitterPower, radio2.TransmitterPower);
            Xunit.Assert.Equal(radio1.HasBluetooth, radio2.HasBluetooth);
        }

        [Fact]
        public void ToString_ContainsRadioInfo()
        {
            var radio = new Radio();
            radio.Manufacturer = "Panasonic";
            radio.Price = 2500;
            radio.TransmitterPower = 8.2;
            radio.HasBluetooth = 1;

            var result = radio.ToString();

            Xunit.Assert.Contains("Panasonic", result);
            Xunit.Assert.Contains("2500", result);
            Xunit.Assert.Contains("8", result); // »щем часть числа
            Xunit.Assert.Contains("1", result);
            Xunit.Assert.Contains("Transmitter power", result);
            Xunit.Assert.Contains("Has bluetooth", result);
        }

        [Fact]
        public void CopyConstructor_CreatesCopy()
        {
            var original = new Radio("jvc", 4000, 6.8, 0);

            var copy = new Radio(original);

            Xunit.Assert.Equal(original.Manufacturer, copy.Manufacturer);
            Xunit.Assert.Equal(original.Price, copy.Price);
            Xunit.Assert.Equal(original.TransmitterPower, copy.TransmitterPower);
            Xunit.Assert.Equal(original.HasBluetooth, copy.HasBluetooth);
        }
    }
}