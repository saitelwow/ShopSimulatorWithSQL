using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMplusDazy.ViewModel
{
    using Model;
    internal class StartWindowVM : BaseVM
    {
        #region Atrybuty
        private string isVisible = "Visible";
        #endregion

        #region GetSet
        public string IsVisible { get { return isVisible; } set { isVisible = value; OnPropertyChanged(nameof(IsVisible)); } }
        #endregion

        #region VMy
        public RegisterWindowVM RWVM { get; set; }
        public LogOwnerVM LOVM { get; set; }
        public LogUserVM LUVM { get; set; }
        #endregion

        public StartWindowVM() { }

        #region Metody
        public void LoginUser(object sender)
        {
            IsVisible = "Hidden";
            LUVM.IsVisible = "Visible";
        }
        public void LoginOwner(object sender)
        {
            IsVisible = "Hidden";
            LOVM.IsVisible = "Visible";
        }
        public void Register(object sender)
        {
            IsVisible = "Hidden";
            RWVM.IsVisible = "Visible";
        }
        #endregion

    }
}
