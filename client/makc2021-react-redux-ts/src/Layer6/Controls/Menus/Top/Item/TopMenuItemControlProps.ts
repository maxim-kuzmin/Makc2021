// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { MenuControlItem } from 'src/Layer6/Control/Menu/MenuControlItem';

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
  menuItem: MenuControlItem;
}
