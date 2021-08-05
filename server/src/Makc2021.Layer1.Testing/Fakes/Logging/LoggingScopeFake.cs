// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Makc2021.Layer1.Testing.Fakes.Logging
{
    /// <summary>
    /// Подделка области видимости логирования.
    /// </summary>
    public class LoggingScopeFake : IDisposable
    {
        #region Properties

        private Stack<Dictionary<string, object>> States { get; } = new Stack<Dictionary<string, object>>();

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public void Dispose()
        {
            lock (States)
            {
                if (States.Any())
                {
                    States.Pop();
                }
            }
        }

        /// <summary>
        /// Заглянуть.
        /// </summary>
        /// <returns>Последнее состояние.</returns>
        public Dictionary<string, object> Peek()
        {
            lock (States)
            {
                return States.Peek();
            }
        }

        /// <summary>
        /// Поместить.
        /// </summary>
        /// <param name="state">Состояние.</param>
        /// <returns>Средство очистки.</returns>
        public IDisposable Push(Dictionary<string, object> state)
        {
            lock (States)
            {
                Dictionary<string, object> nextState;

                if (States.Any())
                {
                    var prevState = States.Peek();

                    nextState = new Dictionary<string, object>(prevState);

                    foreach (string key in state.Keys)
                    {
                        nextState[key] = state[key];
                    }
                }
                else
                {
                    nextState = state;
                }

                States.Push(nextState);

                return this;
            }
        }

        #endregion Public methods
    }
}
