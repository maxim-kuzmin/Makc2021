// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TimingService } from '../Timing/TimingService';

/**
 * Общее хранилище.
 */
export abstract class CommonStore {
  /**
   * Ожидание.
   */
  protected readonly waiting = new TimingService(10, 500);
}
