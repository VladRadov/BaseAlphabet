using System;
using System.Windows.Forms;

namespace Alphabet.View.PersonsOperations
{
    internal interface IPersonsAddOrDeleteView : IPersonsOperationsView
    {
        event Action<string, DateTime, string> InsertTelegramEventHandler;

        event Action<int, int, string> OperationsOnPersonsEventHandler;

        event Action<long> DecisionBakingOnPersonEventHandler;

        event Action<int> HandEditNoFindedPersonsEventHandler;

        event Action<int> GetPersonDTEventHandler;

        event Action<int, int> ChangeBorderRoutingEventHandler;

        void CreateTableResult(object dataPersons);

        DialogResult ShowMessageBox(string message, string title, MessageBoxButtons button, MessageBoxIcon icon);

        void SetEnableControls(bool state);

        void SetEnableControls();

        void UpdateTable();

        void UpdatePersonDT(object dataTable);
    }
}
