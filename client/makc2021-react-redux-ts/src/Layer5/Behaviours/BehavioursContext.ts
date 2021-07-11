// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { FocusBehaviourContext } from './Focus/FocusBehaviourContext';

/**
 * Контекст поведений.
 */
export class BehavioursContext {
  /**
   * Фокус.
   */
  readonly Focus = new FocusBehaviourContext();

  /**
   * Настроить сервисы.
   */
  configureServices() {
    this.Focus.configureServices();
  }
}
