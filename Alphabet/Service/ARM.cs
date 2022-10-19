using System.Windows.Forms;

namespace Alphabet.Service
{
    class ARMManager
    {
        public static ARM EnterARM(string nameARM)
        {
            switch (nameARM)
            {
                case ARMAdministrator.Name:
                    return new ARMAdministrator();
                case ARMFindPersons.Name:
                    return new ARMFindPersons();
                case ARMAddOrDeletePersons.Name:
                    return new ARMAddOrDeletePersons();
                default:
                    return new ARM();
            }
        }
    }

    internal class ARM
    {
        public Form ARMForm { get; set; }
    }

    class ARMAdministrator : ARM
    {
        public const string Name = "АРМ администратора";

        public ARMAdministrator()
        {
            ARMForm = new FormAdministrator();
        }
    }

    class ARMFindPersons : ARM
    {
        public const string Name = "АРМ поиска лиц";

        public ARMFindPersons()
        {
            ARMForm = new SearchForm();
        }
    }

    class ARMAddOrDeletePersons : ARM
    {
        public const string Name = "АРМ постановка/снятие";

        public ARMAddOrDeletePersons()
        {
            ARMForm = new EditForm();
        }
    }
}
