using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationAll.Games
{
    public delegate void DelegateEndOfGame(int idUser, int idGame, int idDefi, int points);

    /// <summary>
    /// Interface pour chaque jeu
    /// Contient un evenement de fin de jeu
    /// </summary>
    public interface IGame
    {
        event DelegateEndOfGame EndOfGameEvent;

        void EndOfGame();
    }
}
