using ProjetSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.ViewModels
{
    class UserInfoViewModel
    {

		private int _identifiant;

		public int Identifiant
		{
			get { return _identifiant; }
			set { _identifiant = value; }
		}

		private UserModel _user;

		public UserModel User
		{
			get { return _user; }
			set { _user = value; }
		}

		private List<ActiviteModel> _historique;

		public List<ActiviteModel> Historique
		{
			get { return _historique; }
			set { _historique = value; }
		}


		public UserInfoViewModel()
		{

		}
	}
}
