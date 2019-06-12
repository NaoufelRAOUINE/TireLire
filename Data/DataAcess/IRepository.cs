﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tirelires.DataAcess
{
    public interface IRepository<T>
    {
        T Ajouter(T nouveau);
        T Modifier(T nouveau);
        void Supprimer(int id);
        ICollection<T> Lister();
        T Trouver(int id);
        int TrouverParEmail(string email);
    }
}
