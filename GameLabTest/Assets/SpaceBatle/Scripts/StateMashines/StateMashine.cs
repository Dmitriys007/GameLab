using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    #region Интерфейсы для машины состояний
    /// <summary>
    /// Машина состояний
    /// </summary>
    public interface IStateParent
    {
        void AplyState(IState newState);

        IState GetState();
    }

    /// <summary>
    /// Базовый интерфейс стейт машин
    /// </summary>
    public interface IState { }

    /// <summary>
    /// Стейт требует уведомления о своей активации
    /// </summary>
    public interface IEnterState : IState
    {
        void OnEnter(IStateParent parrent);
    }

    /// <summary>
    /// Стейт требует уведомления о требовании выхода из состояния
    /// </summary>
    public interface IExitState : IState
    {
        void OnExitState();
    }

    /// <summary>
    /// Требует обновления FixedUpdate
    /// </summary>
    public interface IFixedUpdateble
    {
        void FixedUpdate();
    }
    #endregion
}