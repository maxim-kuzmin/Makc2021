// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { CommonMenuItem } from 'src/Layer6/Common/Menu/CommonMenuItem';

/**
 * Свойства элемента управления "Пункт верхнего меню".
 */
export interface TopMenuItemControlProps {
  /**
   * Имя класса иконки.
   */
  iconClassName?: string;

  /**
   * Пункт меню.
   */
  menuItem: CommonMenuItem;
}
