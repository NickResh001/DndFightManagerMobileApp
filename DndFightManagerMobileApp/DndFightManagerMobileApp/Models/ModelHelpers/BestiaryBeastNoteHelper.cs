using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace DndFightManagerMobileApp.Models.ModelHelpers
{
    public class BestiaryBeastNoteHelper
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string BeastType { get; set; }
        public string ChallengeRatingString { get; set; }
        public double ChallengeRating { get; set; }
        public bool CanBeModified { get; set; }

        public BestiaryBeastNoteHelper() { }
        public BestiaryBeastNoteHelper(BeastNoteModel beastNoteModel)
        {
            Id = beastNoteModel.Id;
            Title = beastNoteModel.Title;
            BeastType = beastNoteModel.BeastType.Title;
            ChallengeRating = beastNoteModel.ChallengeRating;
            ChallengeRatingString = beastNoteModel.ChallangeRatingString();
            CanBeModified = true;
        }

    }
}
