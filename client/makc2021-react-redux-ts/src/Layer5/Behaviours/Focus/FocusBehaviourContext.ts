// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Lazy } from 'src/Layer1/Lazy';
import { FocusBehaviourModule } from './FocusBehaviourModule';
import { FocusBehaviourStore } from './FocusBehaviourStore';

/**
 * Контекст поведения фокуса.
 */
export class FocusBehaviourContext {
  private _module = new FocusBehaviourModule();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    const instanceOfStore = new Lazy<FocusBehaviourStore>(
      () => new FocusBehaviourStore()
    );
    this._module.storeGetter = () => instanceOfStore.value;
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
