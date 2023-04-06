﻿namespace NoteTaking.Web.ViewModels
{
    public class DetailsNoteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string Text { get; set; } = null!;

        public DateTime Date { get; set; }
    }
}