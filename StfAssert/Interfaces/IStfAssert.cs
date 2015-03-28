using System;

namespace Stf.Utilities.StfAssert.Interfaces
{
    public interface IStfAssert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertEquals(String testStep, Object expected, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertBooleanEqual(String testStep, Object expected, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertEqualsCi(String testStep, Object expected, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertNotEquals(String testStep, Object expected, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertNotEqualsCi(String testStep, Object expected, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertNothing(String testStep, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertNotNothing(String testStep, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertEmpty(String testStep, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertNotEmpty(String testStep, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertIsObject(String testStep, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="value"></param>
        /// <param name="expectedTypeName"></param>
        /// <returns>Boolean</returns>
        Boolean AssertIsInstanceOf(String testStep, Object value, String expectedTypeName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertNotNull(String testStep, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertNull(String testStep, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertHasValue(String testStep, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="actual"></param>
        /// <returns>Boolean</returns>
        Boolean AssertHasNoValue(String testStep, Object actual);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="leftHandSide"></param>
        /// <param name="rightHandSide"></param>
        /// <returns>Boolean</returns>
        Boolean AssertGreaterThan(String testStep, Object leftHandSide, Object rightHandSide);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="leftHandSide"></param>
        /// <param name="rightHandSide"></param>
        /// <returns>Boolean</returns>
        Boolean AssertLessThan(String testStep, Object leftHandSide, Object rightHandSide);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="filenameAndPath">Absolut path to the file of interest</param>
        /// <returns>Boolean</returns>
        Boolean AssertFileExists(String testStep, String filenameAndPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="foldernameAndPath"></param>
        /// <returns>Boolean</returns>
        Boolean AssertFolderExists(String testStep, String foldernameAndPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="foldernameAndPath"></param>
        /// <returns>Boolean</returns>
        Boolean AssertFolderNotExists(String testStep, String foldernameAndPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="filenameAndPath">Absolut path to the file of interest</param>
        /// <returns>Boolean</returns>
        Boolean AssertFileNotExists(String testStep, String filenameAndPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="value"></param>
        /// <returns>Boolean</returns>
        Boolean AssertTrue(String testStep, Boolean value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testStep">Name of the test step in the testscript</param>
        /// <param name="value"></param>
        /// <returns>Boolean</returns>
        Boolean AssertFalse(String testStep, Boolean value);

        /// <summary>
        /// 
        /// </summary>
        Boolean EnableNegativeTesting { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        /// <returns>Boolean</returns>
        Boolean CheckHasValue(Object actual, ref String message);

        /// <summary>
        ///Property for the last message reported - used by Unit tests 
        /// </summary>
        String LastMessage { get; }
    }
}
