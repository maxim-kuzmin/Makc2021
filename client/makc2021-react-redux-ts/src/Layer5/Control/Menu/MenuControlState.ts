// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Состояние элемента управления "Меню".
 */
export interface MenuControlState {
  /**
   * Ключ текущего пункта.
   */
  currentItemKey: string;
}

/**
 * Создать состояние элемента управления "Меню".
 * @returns Состояние элемента управления "Меню".
 */
export function createMenuControlState() {
  return {
    currentItemKey: ''
  } as MenuControlState;
}
