﻿using System.ComponentModel;

namespace TravelAgencyBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления путёвки
    /// </summary>
    public class ComponentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}