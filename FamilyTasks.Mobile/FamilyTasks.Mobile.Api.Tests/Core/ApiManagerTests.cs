using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTasks.Mobile.Api.Core;
using FamilyTasks.Mobile.Api.Request;
using FamilyTasks.Mobile.Api.Settings;
using FamilyTasks.Mobile.Api.Tests.Stubs;
using Moq;
using NUnit.Framework;
using RestSharp.Portable;

namespace FamilyTasks.Mobile.Api.Core.Tests
{
    [TestFixture()]
    public class ApiManagerTests
    {
        private SettingsStub _settings;

        [Test()]
        public async void TestAutorizateInRealLoginCheckToken()
        {
           var manager = CreateApiManager();
           var result=await manager.Autorizate(new AutorizationRequest() { UserName = "andrew", Password = "SuperPass" });
            Assert.IsNotNull(result,"При авторизации менеджер вернул null");
            Assert.IsNotNullOrEmpty(result.Result.AccessToken,"Менеджер не вернул токен при регстирации, либо токен пуст");
            Assert.GreaterOrEqual(result.Result.ExpiresIn,0,"Время протухание <=0");
        }

        [Test]
        public async void Autorizate_OnFakeData_ErrorMessage()
        {
            var manager = CreateApiManager();
            var result = await manager.Autorizate(new AutorizationRequest() { UserName = "test", Password = "test" });
            Assert.AreNotEqual(result.ErrorCode,0);
        }

        [Test]
        public async void Autorizate_OnRealData_SettingsSaveToken()
        {
            var manager = CreateApiManager();
            var result = await manager.Autorizate(new AutorizationRequest() { UserName = "andrew", Password = "SuperPass" });
            Assert.IsNotNull(_settings.Token, "Не сохранился токен, при норм учетных данных");
        }

        private IApiManager CreateApiManager()
        {
            _settings = new SettingsStub();
            var cacheStub = new CacheStub();
            var client = new RestClient(_settings.BaseUrl);
            return new ApiManager(new RequestExecuterService(_settings,client));
        }

        [Test()]
        public async void RegisterTest()
        {
           var manager = CreateApiManager();
           var str=await manager.Register(new RegistrationRequest() {ConfirmPassword = "12345", Email = "12345", Password = "12345"});
           Assert.AreEqual(str.ErrorCode,0);
        }

        [Test()]
        public async void GetProjectsListTest()
        {
            var manager = CreateApiManager();
            var str = await manager.GetProjectsList();
        }

        [Test]
        public async void GetProjectListTest_GetWithoutAutorization_ErrorCode()
        {
            var manager = CreateApiManager();
            var str = await manager.GetProjectsList();
            Assert.AreNotEqual(str.ErrorCode,0);
        }
        [Test]
        public async void GetProjectListTest_GetWithAutorization_ProjectsListLoaded()
        {
            var manager = CreateApiManager();
            var result = await manager.Autorizate(new AutorizationRequest() { UserName = "andrew", Password = "SuperPass" });
            var str = await manager.GetProjectsList();
            Assert.NotNull(str.Result);
        }

    }
}
