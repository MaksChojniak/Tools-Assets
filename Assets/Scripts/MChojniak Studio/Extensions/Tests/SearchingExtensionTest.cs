namespace MChojniakStudio.Extensions.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using UnityEngine;
    using UnityEngine.TestTools;

    public class SearchingExtensionTest
    {
        class TestClass : ISearchable
        {
            string title;

            public TestClass(string value)
            {
                title = value;
            }

            public string GetTitle() => title;
        }

        #region GetMatching

        [TestCase("W,Wo,Wor,Worl,World,Worlds", "W", "W,Wo,Wor,Worl,World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "Wo", "Wo,Wor,Worl,World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "Wor", "Wor,Worl,World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "Worl", "Worl,World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "World", "World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "Worlds", "Worlds")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "W", "Worlds,W,World,Worl,Wo,Wor")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "Wo", "Worlds,World,Worl,Wo,Wor")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "Wor", "Worlds,World,Worl,Wor")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "Worl", "Worlds,World,Worl")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "World", "Worlds,World")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "Worlds", "Worlds")]
        [TestCase("Alpha,Beta,Gamma,Delta,Epsilon", "a", "Alpha,Beta,Gamma,Delta")]
        [TestCase("Alpha,Beta,Gamma,Delta,Epsilon", "et", "Beta")]
        [TestCase("Alpha,Beta,Gamma,Delta,Epsilon", "E", "Beta,Delta,Epsilon")]
        [TestCase("foo,bar,baz,foobar,foobaz", "foo", "foo,foobar,foobaz")]
        [TestCase("apple,banana,grape,apricot,orange", "ap", "apple,grape,apricot")]
        [TestCase("cat,dog,bat,rat,mat", "at", "cat,bat,rat,mat")]
        [TestCase("red,green,blue,yellow,orange", "e", "red,green,blue,yellow,orange")]
        [TestCase("sun,moon,star,planet,comet", "n", "sun,moon,planet")]
        [TestCase("car,bus,bike,train,plane", "b", "bus,bike")]
        [TestCase("table,chair,sofa,desk,bed", "e", "table,desk,bed")]
        [TestCase("pen,pencil,eraser,marker,sharpener", "pen", "pen,pencil,sharpener")]
        [TestCase("lion,tiger,bear,wolf,fox", "o", "lion,wolf,fox")]
        [TestCase("spring,summer,autumn,winter", "um", "summer,autumn")]
        [TestCase("monday,tuesday,wednesday,thursday,friday", "day", "monday,tuesday,wednesday,thursday,friday")]
        [TestCase("circle,square,triangle,rectangle,oval", "le", "circle,triangle,rectangle")]
        [TestCase("milk,cheese,butter,yogurt,cream", "e", "cheese,butter,cream")]
        [TestCase("rose,lily,tulip,daisy,orchid", "li", "lily,tulip")]
        [TestCase("python,java,csharp,javascript,swift", "java", "java,javascript")]
        [TestCase("one,two,three,four,five", "o", "one,two,four")]
        [TestCase("north,south,east,west", "st", "east,west")]
        [TestCase("book,notebook,magazine,journal,diary", "book", "book,notebook")]
        [TestCase("mouse,keyboard,monitor,printer,scanner", "er", "printer,scanner")]
        [TestCase("doctor,nurse,patient,surgeon,therapist", "ur", "nurse,surgeon")]
        [TestCase("pizza,burger,salad,pasta,soup", "sa", "salad")]
        [TestCase("mountain,river,lake,forest,desert", "r", "river,forest,desert")]
        [TestCase("facebook,twitter,instagram,linkedin,snapchat", "in", "instagram,linkedin")]
        [TestCase("football,basketball,baseball,tennis,golf", "ball", "football,basketball,baseball")]
        [TestCase("paris,london,berlin,rome,madrid", "on", "london")]
        [TestCase("google,apple,microsoft,amazon,facebook", "oo", "google,facebook")]
        [TestCase("sunflower,rose,tulip,daisy,lily", "li", "tulip,lily")]
        [TestCase("spoon,fork,knife,plate,cup", "p", "spoon,plate,cup")]
        [TestCase("earth,mars,venus,jupiter,saturn", "ar", "earth,mars")]
        [TestCase("black,white,gray,red,blue", "a", "black,gray")]
        [TestCase("apple,banana,grape,apricot,orange", "banana", "banana")]
        [TestCase("cat,dog,bat,rat,mat", "cat", "cat")]
        [TestCase("red,green,blue,yellow,orange", "yellow", "yellow")]
        [TestCase("sun,moon,star,planet,comet", "planet", "planet")]
        [TestCase("car,bus,bike,train,plane", "train", "train")]
        [TestCase("table,chair,sofa,desk,bed", "chair", "chair")]
        [TestCase("pen,pencil,eraser,marker,sharpener", "sharpener", "sharpener")]
        [TestCase("lion,tiger,bear,wolf,fox", "tiger", "tiger")]
        [TestCase("spring,summer,autumn,winter", "summer", "summer")]
        [TestCase("monday,tuesday,wednesday,thursday,friday", "wednesday", "wednesday")]
        [TestCase("circle,square,triangle,rectangle,oval", "rectangle", "rectangle")]
        [TestCase("milk,cheese,butter,yogurt,cream", "cheese", "cheese")]
        [TestCase("rose,lily,tulip,daisy,orchid", "orchid", "orchid")]
        [TestCase("python,java,csharp,javascript,swift", "javascript", "javascript")]
        [TestCase("book,notebook,magazine,journal,diary", "notebook", "notebook")]
        [TestCase("apple,banana,grape,apricot,orange", "pear", "")]
        [TestCase("cat,dog,bat,rat,mat", "hamster", "")]
        [TestCase("red,green,blue,yellow,orange", "purple", "")]
        [TestCase("sun,moon,star,planet,comet", "asteroid", "")]
        [TestCase("car,bus,bike,train,plane", "boat", "")]
        [TestCase("table,chair,sofa,desk,bed", "couch", "")]
        [TestCase("pen,pencil,eraser,marker,sharpener", "crayon", "")]
        [TestCase("lion,tiger,bear,wolf,fox", "leopard", "")]
        [TestCase("spring,summer,autumn,winter", "fall", "")]
        [TestCase("monday,tuesday,wednesday,thursday,friday", "saturday", "")]
        [TestCase("circle,square,triangle,rectangle,oval", "hexagon", "")]
        [TestCase("milk,cheese,butter,yogurt,cream", "icecream", "")]
        [TestCase("rose,lily,tulip,daisy,orchid", "sunflower", "")]
        [TestCase("python,java,csharp,javascript,swift", "ruby", "")]
        [TestCase("book,notebook,magazine,journal,diary", "calendar", "")]
        public void UnitTest_EditMode_ReflectionExtension_GetMatching(string sourceText, string value, string expectedResultText)
        {
            IEnumerable<ISearchable> source = sourceText.Split(',').Where(title => !string.IsNullOrEmpty(title)).Select(title => new TestClass(title));
            IEnumerable<ISearchable> expectedResult = expectedResultText.Split(',').Where(title => !string.IsNullOrEmpty(title)).Select(title => new TestClass(title));

            IEnumerable<ISearchable> result = source.GetMatching(value);
            Assert.AreEqual(string.Join(",", expectedResult.Select(item => item.GetTitle())), string.Join(",", result.Select(item => item.GetTitle())));
        }

        #endregion


        #region SortByMatching

        [TestCase("W,Wo,Wowo,Worl,World,Worlds", "Wo", "Wowo,Wo,Worl,World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "W", "W,Wo,Wor,Worl,World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "Wo", "Wo,Wor,Worl,World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "Wor", "Wor,Worl,World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "Worl", "Worl,World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "World", "World,Worlds")]
        [TestCase("W,Wo,Wor,Worl,World,Worlds", "Worlds", "Worlds")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "W", "W,Wo,Wor,Worl,World,Worlds")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "Wo", "Wo,Wor,Worl,World,Worlds")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "Wor", "Wor,Worl,World,Worlds")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "Worl", "Worl,World,Worlds")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "World", "World,Worlds")]
        [TestCase("Worlds,W,World,Worl,Wo,Wor", "Worlds", "Worlds")]
        [TestCase("Alpha,Beta,Gamma,Delta,Epsilon", "a", "Alpha,Gamma,Beta,Delta")]
        [TestCase("Alpha,Beta,Gamma,Delta,Epsilon", "et", "Beta")]
        [TestCase("Alpha,Beta,Gamma,Delta,Epsilon", "E", "Beta,Delta,Epsilon")]
        [TestCase("foo,bar,baz,foobar,foobaz", "foo", "foo,foobar,foobaz")]
        [TestCase("apple,banana,grape,apricot,orange", "ap", "apple,apricot,grape")]
        [TestCase("cat,dog,bat,rat,mat", "at", "bat,cat,mat,rat")]
        [TestCase("red,green,blue,yellow,orange", "e", "green,blue,orange,red,yellow")]
        [TestCase("sun,moon,star,planet,comet", "n", "moon,planet,sun")]
        [TestCase("car,bus,bike,train,plane", "b", "bike,bus")]
        [TestCase("table,chair,sofa,desk,bed", "e", "bed,desk,table")]
        [TestCase("pen,pencil,eraser,marker,sharpener", "pen", "pen,pencil,sharpener")]
        [TestCase("lion,tiger,bear,wolf,fox", "o", "fox,lion,wolf")]
        [TestCase("spring,summer,autumn,winter", "um", "autumn,summer")]
        [TestCase("monday,tuesday,wednesday,thursday,friday", "day", "friday,monday,thursday,tuesday,wednesday")]
        [TestCase("circle,square,triangle,rectangle,oval", "le", "circle,rectangle,triangle")]
        [TestCase("milk,cheese,butter,yogurt,cream", "e", "cheese,butter,cream")]
        [TestCase("rose,lily,tulip,daisy,orchid", "li", "lily,tulip")]
        [TestCase("python,java,csharp,javascript,swift", "java", "java,javascript")]
        [TestCase("one,two,three,four,five", "o", "four,one,two")]
        [TestCase("north,south,east,west", "st", "east,west")]
        [TestCase("book,notebook,magazine,journal,diary", "book", "book,notebook")]
        [TestCase("mouse,keyboard,monitor,printer,scanner", "er", "printer,scanner")]
        [TestCase("doctor,nurse,patient,surgeon,therapist", "ur", "nurse,surgeon")]
        [TestCase("pizza,burger,salad,pasta,soup", "sa", "salad")]
        [TestCase("mountain,river,lake,forest,desert", "r", "river,desert,forest")]
        [TestCase("facebook,twitter,instagram,linkedin,snapchat", "in", "linkedin,instagram")]
        [TestCase("football,basketball,baseball,tennis,golf", "ball", "baseball,basketball,football")]
        [TestCase("paris,london,berlin,rome,madrid", "on", "london")]
        [TestCase("google,apple,microsoft,amazon,facebook", "oo", "facebook,google")]
        [TestCase("sunflower,rose,tulip,daisy,lily", "li", "lily,tulip")]
        [TestCase("spoon,fork,knife,plate,cup", "p", "cup,plate,spoon")]
        [TestCase("earth,mars,venus,jupiter,saturn", "ar", "earth,mars")]
        [TestCase("black,white,gray,red,blue", "a", "black,gray")]
        [TestCase("apple,banana,grape,apricot,orange", "banana", "banana")]
        [TestCase("cat,dog,bat,rat,mat", "cat", "cat")]
        [TestCase("red,green,blue,yellow,orange", "yellow", "yellow")]
        [TestCase("sun,moon,star,planet,comet", "planet", "planet")]
        [TestCase("car,bus,bike,train,plane", "train", "train")]
        [TestCase("table,chair,sofa,desk,bed", "chair", "chair")]
        [TestCase("pen,pencil,eraser,marker,sharpener", "sharpener", "sharpener")]
        [TestCase("lion,tiger,bear,wolf,fox", "tiger", "tiger")]
        [TestCase("spring,summer,autumn,winter", "summer", "summer")]
        [TestCase("monday,tuesday,wednesday,thursday,friday", "wednesday", "wednesday")]
        [TestCase("circle,square,triangle,rectangle,oval", "rectangle", "rectangle")]
        [TestCase("milk,cheese,butter,yogurt,cream", "cheese", "cheese")]
        [TestCase("rose,lily,tulip,daisy,orchid", "orchid", "orchid")]
        [TestCase("python,java,csharp,javascript,swift", "javascript", "javascript")]
        [TestCase("book,notebook,magazine,journal,diary", "notebook", "notebook")]
        [TestCase("apple,banana,grape,apricot,orange", "pear", "")]
        [TestCase("cat,dog,bat,rat,mat", "hamster", "")]
        [TestCase("red,green,blue,yellow,orange", "purple", "")]
        [TestCase("sun,moon,star,planet,comet", "asteroid", "")]
        [TestCase("car,bus,bike,train,plane", "boat", "")]
        [TestCase("table,chair,sofa,desk,bed", "couch", "")]
        [TestCase("pen,pencil,eraser,marker,sharpener", "crayon", "")]
        [TestCase("lion,tiger,bear,wolf,fox", "leopard", "")]
        [TestCase("spring,summer,autumn,winter", "fall", "")]
        [TestCase("monday,tuesday,wednesday,thursday,friday", "saturday", "")]
        [TestCase("circle,square,triangle,rectangle,oval", "hexagon", "")]
        [TestCase("milk,cheese,butter,yogurt,cream", "icecream", "")]
        [TestCase("rose,lily,tulip,daisy,orchid", "sunflower", "")]
        [TestCase("python,java,csharp,javascript,swift", "ruby", "")]
        [TestCase("book,notebook,magazine,journal,diary", "calendar", "")]
        public void UnitTest_EditMode_ReflectionExtension_SortByMatching(string sourceText, string value, string expectedResultText)
        {
            IEnumerable<ISearchable> source = sourceText.Split(',').Where(title => !string.IsNullOrEmpty(title)).Select(title => new TestClass(title));
            IEnumerable<ISearchable> expectedResult = expectedResultText.Split(',').Where(title => !string.IsNullOrEmpty(title)).Select(title => new TestClass(title));

            IEnumerable<ISearchable> result = source.GetMatching(value).SortByMatching(value); ;
            Assert.AreEqual(string.Join(",", expectedResult.Select(item => item.GetTitle())), string.Join(",", result.Select(item => item.GetTitle())));
        }

        #endregion

    }
}
