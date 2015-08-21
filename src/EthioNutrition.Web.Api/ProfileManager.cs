using NHibernate;
using System;

namespace EthioNutrition.Web.Api
{
    public class ProfileManager: IProfileManager
    {
        private readonly ISession _session;

        public ProfileManager(ISession session)
        {
            _session = session;
        }

        public long CreateProfile()
        {
            var userProfile = new Data.Models.UserProfile { };
            _session.Save(userProfile);

            return userProfile.ProfileID;
        }
    }
}