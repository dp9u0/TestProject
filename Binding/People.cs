// FileName:  People.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180510 17:14
// Description:   

#region

using System.Collections.ObjectModel;

#endregion

namespace Binding {

    public class People : ObservableCollection<Person> {

        public People() {
            Add(new Person {FirstName = "111", LastName = "111", HomeTown = "111"});
            Add(new Person {FirstName = "222", LastName = "222", HomeTown = "222" });
            Add(new Person {FirstName = "333", LastName = "333", HomeTown = "333"});
            Add(new Person {FirstName = "444", LastName = "444", HomeTown = "444" });
            Add(new Person {FirstName = "555", LastName = "555", HomeTown = "555" });
        }

    }

}