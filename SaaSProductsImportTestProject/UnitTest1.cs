using Moq;
using SaaSProductsImport;
using SaaSProductsImport.enums;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace SaaSProductsImportTestProject
{
    public class UnitTest1
    {
        #region Property  
        public Mock<SourceLogic> mock;
        #endregion

        [Fact]
        public void CheckResultCollection()
        {
            string filePath = "C:/Users/Vaishali/source/repos/SaaSProductsImport/SaaSProductsImport/feed-products/capterra.yaml";

            List<Dictionary<CapterraEnum, string>> result = SourceLogic.GetCapterraYamlToObject(filePath);
            IEnumerator e = result.GetEnumerator();
            if (e.MoveNext())
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(false);
            }

        }
    }
}
