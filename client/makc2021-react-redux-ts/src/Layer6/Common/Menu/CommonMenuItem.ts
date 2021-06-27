// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Пункт общего меню.
 */
export interface CommonMenuItem {
  /**
   * Дети.
   */
  children?: CommonMenuItem[];

  /**
   * Признак открытия в новой вкладке.
   */
  isOpenInNewTab: boolean;

  /**
   * Признак внешнего пути.
   */
  isPathExternal: boolean;

  /**
   * Ключ.
   */
  key: string;

  /**
   * Родитель.
   */
  parent?: CommonMenuItem;

  /**
   * Путь.
   */
  path: string;

  /**
   * Текст.
   */
  text: string;
}

/**
 * Создать пункт общего меню.
 * @param key Ключ.
 * @returns Пункт общего меню.
 */
export function createCommonMenuItem(key: string) {
  return {
    isOpenInNewTab: false,
    isPathExternal: false,
    key,
    path: '',
    text: ''
  } as CommonMenuItem;
}
