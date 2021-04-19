// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TimingService } from './TimingService';

/**
 * Фабрика согласования.
 */
export class TimingFactory {
  /**
   * Создать ожидание.
   */
  createWaiting() {
    return new TimingService(10, 500);
  }
}
