// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Состояние элемента управления "Ожидание".
 */
export interface WaitingControlState {
  /**
   * Признак видимости.
   */
  isVisible: boolean;
}

/**
 * Создать состояние элемента упроавления "Ожидание".
 * @returns Состояние элемента упроавления "Ожидание".
 */
export function createWaitingControlState() {
  return {
    isVisible: false
  } as WaitingControlState;
}
