// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { TimingFactory } from '../Timing/TimingFactory';

/**
 * Общее хранилище.
 */
export abstract class CommonStore {
  /**
   * Конструктор.
   * @param appTimingFactory Фабрика согласования.
   */
  constructor(protected readonly appTimingFactory: TimingFactory) {}
}
