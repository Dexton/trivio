using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using trivio.Services;
using trivio.Clients;
using trivio.Models;
using static trivio.Program;

namespace trivio.Tests
{
    public class FactServiceTests
    {
        IFactService _service;
        Mock<ICatsClient> _catsMock = new Mock<ICatsClient>();
        Mock<ICountriesClient> _countriesMock = new Mock<ICountriesClient>();
        Mock<INumbersClient> _numbersMock = new Mock<INumbersClient>();
        List<String> _countries = new List<string>() {"Iceland", "Denmark"};

        public FactServiceTests() {

            var settings = new AppSettings() { Countries=_countries};
            _service = new FactService(_catsMock.Object, _countriesMock.Object, _numbersMock.Object, Options.Create(settings));
        }

        [Fact]
        public async void ShouldReturnCatFact()
        {
            string testWord = "A Word";
            _catsMock.Setup(mock => mock.IsApplicable(testWord)).Returns(true);
            Fact result = await _service.GetFact(testWord);
            _catsMock.Verify(mock => mock.GetFact(testWord), Times.Once());
        }

        [Fact]
        public async void ShouldReturnNumbersFact()
        {
            string testWord = "A Word";
            _numbersMock.Setup(mock => mock.IsApplicable(testWord)).Returns(true);
            Fact result = await _service.GetFact(testWord);
            _numbersMock.Verify(mock => mock.GetFact(testWord), Times.Once());
        }

        [Fact]
        public async void ShouldReturnCountriesFact()
        {
            string testWord = _countries[0];
            _numbersMock.Setup(mock => mock.IsApplicable(testWord)).Returns(true);
            Fact result = await _service.GetFact(testWord);
            _numbersMock.Verify(mock => mock.GetFact(testWord), Times.Once());
        }
    }
}