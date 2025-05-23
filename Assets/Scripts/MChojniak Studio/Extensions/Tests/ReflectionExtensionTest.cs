namespace MChojniakStudio.Extensions.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;
    using UnityEngine;
    using UnityEngine.TestTools;

    public class ReflectionExtensionTest
    {

        #region IsRealAssignableFrom

        // short
        [TestCase(typeof(short), typeof(short), true, Description = "Conversion Type: short to short", Category = "short")]
        [TestCase(typeof(short), typeof(ushort), false, Description = "Conversion Type: short to ushort", Category = "short")]
        [TestCase(typeof(short), typeof(int), true, Description = "Conversion Type: short to int", Category = "short")]
        [TestCase(typeof(short), typeof(uint), false, Description = "Conversion Type: short to uint", Category = "short")]
        [TestCase(typeof(short), typeof(long), true, Description = "Conversion Type: short to long", Category = "short")]
        [TestCase(typeof(short), typeof(ulong), false, Description = "Conversion Type: short to ulong", Category = "short")]
        [TestCase(typeof(short), typeof(float), true, Description = "Conversion Type: short to float", Category = "short")]
        [TestCase(typeof(short), typeof(double), true, Description = "Conversion Type: short to double", Category = "short")]
        [TestCase(typeof(short), typeof(string), false, Description = "Conversion Type: short to string", Category = "short")]
        [TestCase(typeof(short), typeof(char), false, Description = "Conversion Type: short to char", Category = "short")]
        [TestCase(typeof(short), typeof(object), true, Description = "Conversion Type: short to object", Category = "short")]

        // ushort
        [TestCase(typeof(ushort), typeof(short), false, Description = "Conversion Type: ushort to short", Category = "ushort")]
        [TestCase(typeof(ushort), typeof(ushort), true, Description = "Conversion Type: ushort to ushort", Category = "ushort")]
        [TestCase(typeof(ushort), typeof(int), true, Description = "Conversion Type: ushort to int", Category = "ushort")]
        [TestCase(typeof(ushort), typeof(uint), true, Description = "Conversion Type: ushort to uint", Category = "ushort")]
        [TestCase(typeof(ushort), typeof(long), true, Description = "Conversion Type: ushort to long", Category = "ushort")]
        [TestCase(typeof(ushort), typeof(ulong), true, Description = "Conversion Type: ushort to ulong", Category = "ushort")]
        [TestCase(typeof(ushort), typeof(float), true, Description = "Conversion Type: ushort to float", Category = "ushort")]
        [TestCase(typeof(ushort), typeof(double), true, Description = "Conversion Type: ushort to double", Category = "ushort")]
        [TestCase(typeof(ushort), typeof(string), false, Description = "Conversion Type: ushort to string", Category = "ushort")]
        [TestCase(typeof(ushort), typeof(char), true, Description = "Conversion Type: ushort to char", Category = "ushort")]
        [TestCase(typeof(ushort), typeof(object), true, Description = "Conversion Type: ushort to object", Category = "ushort")]

        // int
        [TestCase(typeof(int), typeof(short), false, Description = "Conversion Type: int to short", Category = "int")]
        [TestCase(typeof(int), typeof(ushort), false, Description = "Conversion Type: int to ushort", Category = "int")]
        [TestCase(typeof(int), typeof(int), true, Description = "Conversion Type: int to int", Category = "int")]
        [TestCase(typeof(int), typeof(uint), false, Description = "Conversion Type: int to uint", Category = "int")]
        [TestCase(typeof(int), typeof(long), true, Description = "Conversion Type: int to long", Category = "int")]
        [TestCase(typeof(int), typeof(ulong), false, Description = "Conversion Type: int to ulong", Category = "int")]
        [TestCase(typeof(int), typeof(float), true, Description = "Conversion Type: int to float", Category = "int")]
        [TestCase(typeof(int), typeof(double), true, Description = "Conversion Type: int to double", Category = "int")]
        [TestCase(typeof(int), typeof(string), false, Description = "Conversion Type: int to string", Category = "int")]
        [TestCase(typeof(int), typeof(char), false, Description = "Conversion Type: int to char", Category = "int")]
        [TestCase(typeof(int), typeof(object), true, Description = "Conversion Type: int to object", Category = "int")]

        // uint
        [TestCase(typeof(uint), typeof(short), false, Description = "Conversion Type: uint to short", Category = "uint")]
        [TestCase(typeof(uint), typeof(ushort), false, Description = "Conversion Type: uint to ushort", Category = "uint")]
        [TestCase(typeof(uint), typeof(int), false, Description = "Conversion Type: uint to int", Category = "uint")]
        [TestCase(typeof(uint), typeof(uint), true, Description = "Conversion Type: uint to uint", Category = "uint")]
        [TestCase(typeof(uint), typeof(long), true, Description = "Conversion Type: uint to long", Category = "uint")]
        [TestCase(typeof(uint), typeof(ulong), true, Description = "Conversion Type: uint to ulong", Category = "uint")]
        [TestCase(typeof(uint), typeof(float), true, Description = "Conversion Type: uint to float", Category = "uint")]
        [TestCase(typeof(uint), typeof(double), true, Description = "Conversion Type: uint to double", Category = "uint")]
        [TestCase(typeof(uint), typeof(string), false, Description = "Conversion Type: uint to string", Category = "uint")]
        [TestCase(typeof(uint), typeof(char), false, Description = "Conversion Type: uint to char", Category = "uint")]
        [TestCase(typeof(uint), typeof(object), true, Description = "Conversion Type: uint to object", Category = "uint")]

        // long
        [TestCase(typeof(long), typeof(short), false, Description = "Conversion Type: long to short", Category = "long")]
        [TestCase(typeof(long), typeof(ushort), false, Description = "Conversion Type: long to ushort", Category = "long")]
        [TestCase(typeof(long), typeof(int), false, Description = "Conversion Type: long to int", Category = "long")]
        [TestCase(typeof(long), typeof(uint), false, Description = "Conversion Type: long to uint", Category = "long")]
        [TestCase(typeof(long), typeof(long), true, Description = "Conversion Type: long to long", Category = "long")]
        [TestCase(typeof(long), typeof(ulong), false, Description = "Conversion Type: long to ulong", Category = "long")]
        [TestCase(typeof(long), typeof(float), true, Description = "Conversion Type: long to float", Category = "long")]
        [TestCase(typeof(long), typeof(double), true, Description = "Conversion Type: long to double", Category = "long")]
        [TestCase(typeof(long), typeof(string), false, Description = "Conversion Type: long to string", Category = "long")]
        [TestCase(typeof(long), typeof(char), false, Description = "Conversion Type: long to char", Category = "long")]
        [TestCase(typeof(long), typeof(object), true, Description = "Conversion Type: long to object", Category = "long")]

        // ulong
        [TestCase(typeof(ulong), typeof(short), false, Description = "Conversion Type: ulong to short", Category = "ulong")]
        [TestCase(typeof(ulong), typeof(ushort), false, Description = "Conversion Type: ulong to ushort", Category = "ulong")]
        [TestCase(typeof(ulong), typeof(int), false, Description = "Conversion Type: ulong to int", Category = "ulong")]
        [TestCase(typeof(ulong), typeof(uint), false, Description = "Conversion Type: ulong to uint", Category = "ulong")]
        [TestCase(typeof(ulong), typeof(long), false, Description = "Conversion Type: ulong to long", Category = "ulong")]
        [TestCase(typeof(ulong), typeof(ulong), true, Description = "Conversion Type: ulong to ulong", Category = "ulong")]
        [TestCase(typeof(ulong), typeof(float), true, Description = "Conversion Type: ulong to float", Category = "ulong")]
        [TestCase(typeof(ulong), typeof(double), true, Description = "Conversion Type: ulong to double", Category = "ulong")]
        [TestCase(typeof(ulong), typeof(string), false, Description = "Conversion Type: ulong to string", Category = "ulong")]
        [TestCase(typeof(ulong), typeof(char), false, Description = "Conversion Type: ulong to char", Category = "ulong")]
        [TestCase(typeof(ulong), typeof(object), true, Description = "Conversion Type: ulong to object", Category = "ulong")]

        // float
        [TestCase(typeof(float), typeof(short), false, Description = "Conversion Type: float to short", Category = "float")]
        [TestCase(typeof(float), typeof(ushort), false, Description = "Conversion Type: float to ushort", Category = "float")]
        [TestCase(typeof(float), typeof(int), false, Description = "Conversion Type: float to int", Category = "float")]
        [TestCase(typeof(float), typeof(uint), false, Description = "Conversion Type: float to uint", Category = "float")]
        [TestCase(typeof(float), typeof(long), false, Description = "Conversion Type: float to long", Category = "float")]
        [TestCase(typeof(float), typeof(ulong), false, Description = "Conversion Type: float to ulong", Category = "float")]
        [TestCase(typeof(float), typeof(float), true, Description = "Conversion Type: float to float", Category = "float")]
        [TestCase(typeof(float), typeof(double), true, Description = "Conversion Type: float to double", Category = "float")]
        [TestCase(typeof(float), typeof(string), false, Description = "Conversion Type: float to string", Category = "float")]
        [TestCase(typeof(float), typeof(char), false, Description = "Conversion Type: float to char", Category = "float")]
        [TestCase(typeof(float), typeof(object), true, Description = "Conversion Type: float to object", Category = "float")]

        // double
        [TestCase(typeof(double), typeof(short), false, Description = "Conversion Type: double to short", Category = "double")]
        [TestCase(typeof(double), typeof(ushort), false, Description = "Conversion Type: double to ushort", Category = "double")]
        [TestCase(typeof(double), typeof(int), false, Description = "Conversion Type: double to int", Category = "double")]
        [TestCase(typeof(double), typeof(uint), false, Description = "Conversion Type: double to uint", Category = "double")]
        [TestCase(typeof(double), typeof(long), false, Description = "Conversion Type: double to long", Category = "double")]
        [TestCase(typeof(double), typeof(ulong), false, Description = "Conversion Type: double to ulong", Category = "double")]
        [TestCase(typeof(double), typeof(float), false, Description = "Conversion Type: double to float", Category = "double")]
        [TestCase(typeof(double), typeof(double), true, Description = "Conversion Type: double to double", Category = "double")]
        [TestCase(typeof(double), typeof(string), false, Description = "Conversion Type: double to string", Category = "double")]
        [TestCase(typeof(double), typeof(char), false, Description = "Conversion Type: double to char", Category = "double")]
        [TestCase(typeof(double), typeof(object), true, Description = "Conversion Type: double to object", Category = "double")]

        // char
        [TestCase(typeof(char), typeof(short), false, Description = "Conversion Type: char to short", Category = "char")]
        [TestCase(typeof(char), typeof(ushort), true, Description = "Conversion Type: char to ushort", Category = "char")]
        [TestCase(typeof(char), typeof(int), true, Description = "Conversion Type: char to int", Category = "char")]
        [TestCase(typeof(char), typeof(uint), true, Description = "Conversion Type: char to uint", Category = "char")]
        [TestCase(typeof(char), typeof(long), true, Description = "Conversion Type: char to long", Category = "char")]
        [TestCase(typeof(char), typeof(ulong), true, Description = "Conversion Type: char to ulong", Category = "char")]
        [TestCase(typeof(char), typeof(float), true, Description = "Conversion Type: char to float", Category = "char")]
        [TestCase(typeof(char), typeof(double), true, Description = "Conversion Type: char to double", Category = "char")]
        [TestCase(typeof(char), typeof(string), false, Description = "Conversion Type: char to string", Category = "char")]
        [TestCase(typeof(char), typeof(char), true, Description = "Conversion Type: char to char", Category = "char")]
        [TestCase(typeof(char), typeof(object), true, Description = "Conversion Type: char to object", Category = "char")]

        // string
        [TestCase(typeof(string), typeof(short), false, Description = "Conversion Type: string to short", Category = "string")]
        [TestCase(typeof(string), typeof(ushort), false, Description = "Conversion Type: string to ushort", Category = "string")]
        [TestCase(typeof(string), typeof(int), false, Description = "Conversion Type: string to int", Category = "string")]
        [TestCase(typeof(string), typeof(uint), false, Description = "Conversion Type: string to uint", Category = "string")]
        [TestCase(typeof(string), typeof(long), false, Description = "Conversion Type: string to long", Category = "string")]
        [TestCase(typeof(string), typeof(ulong), false, Description = "Conversion Type: string to ulong", Category = "string")]
        [TestCase(typeof(string), typeof(float), false, Description = "Conversion Type: string to float", Category = "string")]
        [TestCase(typeof(string), typeof(double), false, Description = "Conversion Type: string to double", Category = "string")]
        [TestCase(typeof(string), typeof(string), true, Description = "Conversion Type: string to string", Category = "string")]
        [TestCase(typeof(string), typeof(char), false, Description = "Conversion Type: string to char", Category = "string")]
        [TestCase(typeof(string), typeof(object), true, Description = "Conversion Type: string to object", Category = "string")]

        // object
        [TestCase(typeof(object), typeof(short), false, Description = "Conversion Type: object to short", Category = "object")]
        [TestCase(typeof(object), typeof(ushort), false, Description = "Conversion Type: object to ushort", Category = "object")]
        [TestCase(typeof(object), typeof(int), false, Description = "Conversion Type: object to int", Category = "object")]
        [TestCase(typeof(object), typeof(uint), false, Description = "Conversion Type: object to uint", Category = "object")]
        [TestCase(typeof(object), typeof(long), false, Description = "Conversion Type: object to long", Category = "object")]
        [TestCase(typeof(object), typeof(ulong), false, Description = "Conversion Type: object to ulong", Category = "object")]
        [TestCase(typeof(object), typeof(float), false, Description = "Conversion Type: object to float", Category = "object")]
        [TestCase(typeof(object), typeof(double), false, Description = "Conversion Type: object to double", Category = "object")]
        [TestCase(typeof(object), typeof(string), false, Description = "Conversion Type: object to string", Category = "object")]
        [TestCase(typeof(object), typeof(char), false, Description = "Conversion Type: object to char", Category = "object")]
        [TestCase(typeof(object), typeof(object), true, Description = "Conversion Type: object to object", Category = "object")]

        // decimal
        [TestCase(typeof(decimal), typeof(sbyte), false, Description = "Conversion Type: decimal to sbyte", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(byte), false, Description = "Conversion Type: decimal to byte", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(short), false, Description = "Conversion Type: decimal to short", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(ushort), false, Description = "Conversion Type: decimal to ushort", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(int), false, Description = "Conversion Type: decimal to int", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(uint), false, Description = "Conversion Type: decimal to uint", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(long), false, Description = "Conversion Type: decimal to long", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(ulong), false, Description = "Conversion Type: decimal to ulong", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(float), false, Description = "Conversion Type: decimal to float", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(double), false, Description = "Conversion Type: decimal to double", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(char), false, Description = "Conversion Type: decimal to char", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(string), false, Description = "Conversion Type: decimal to string", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(object), true, Description = "Conversion Type: decimal to object", Category = "decimal")]
        [TestCase(typeof(decimal), typeof(decimal), true, Description = "Conversion Type: decimal to decimal", Category = "decimal")]
        public void UnitTest_EditMode_ReflectionExtension_IsAssignableTo(Type from, Type to, bool expectedResult)
        {
            bool result = from.IsAssignableTo(to);
            Assert.AreEqual(expectedResult, result);//, $"Expected {from.Name} to be assignable to {to.Name}");
        }

        #endregion

    }
}
