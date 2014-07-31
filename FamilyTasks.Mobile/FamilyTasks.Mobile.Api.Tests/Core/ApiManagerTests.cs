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
        private SettingsServiceStub _settingsService;

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
            Assert.IsNotNull(_settingsService.Token, "Не сохранился токен, при норм учетных данных");
        }

        private IApiManager CreateApiManager()
        {
            _settingsService = new SettingsServiceStub();
            var cacheStub = new CacheStub();
            var client = new RestClient(_settingsService.BaseUrl);
            return new ApiManager(new RequestExecuterService(_settingsService));
        }

        [Test()]
        public async void RegisterTest()
        {
           var manager = CreateApiManager();
           var str=await manager.Register(new RegistrationRequest() {ConfirmPassword = "123456", Email = "12345", Password = "123456"});
           Assert.AreEqual(str.ErrorCode,0);
        }

      
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async void GetProjectsListTest(bool isAuth)
        {
            var manager = CreateApiManager();
            if (isAuth)
            {
                var result =
                    await manager.Autorizate(new AutorizationRequest() {UserName = "andrew", Password = "SuperPass"});
            }
            
            var str = await manager.GetProjectsList();
            if (isAuth)
            {
                Assert.IsNotNull(str.Result);
            }
            else
            {
                Assert.IsNull(str.Result);
            }
        }


        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async void GetTaskByProjectIdTest(bool isAuth)
        {
            var manager = CreateApiManager();
            if (isAuth)
            {
                var result = await manager.Autorizate(new AutorizationRequest() { UserName = "andrew", Password = "SuperPass" });
            }
            var str = await manager.GetTaskByProjectId(1);
            if (isAuth)
            {
                Assert.IsNotNull(str.Result);
            }
            else
            {
                Assert.IsNull(str.Result);
            }
            
        }
      

    }
}
