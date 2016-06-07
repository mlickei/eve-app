using Xunit;
using EveOnlineMissioningApp.Models;
using System;

namespace PasswordCredentialTests
{

    public class PasswordCredentialTest
    {

        private String testString = "test";
        private String expectedResult = "1b4f0e9851971998e732078544c96b36c3d01cedf7caa332359d6f1d83567014";
        private int testId = 1;

        [Fact]
        public void TestGetHashString()
        {
            PasswordCredential credential = new PasswordCredential();
            credential.id = testId;

            Salt salt = new Salt();
            salt.id = testId;

            credential.salt = salt;
            String generateStr = credential.getHashString(testString);

            Assert.Equal(generateStr, expectedResult);
        }

        [Fact]
        public void TestAuthenticateTrue()
        {
            PasswordCredential credential = new PasswordCredential();
            credential.id = testId;

            Salt salt = new Salt();
            salt.id = testId;

            credential.salt = salt;
            credential.hash = expectedResult;

            Assert.True(credential.authenticate(testString));
        }

        [Fact]
        public void TestAuthenticateFalse()
        {
            PasswordCredential credential = new PasswordCredential();
            credential.id = testId;

            Salt salt = new Salt();
            salt.id = testId;

            credential.salt = salt;
            credential.hash = "Fake Result";

            Assert.False(credential.authenticate(testString));
        }

    }

}
