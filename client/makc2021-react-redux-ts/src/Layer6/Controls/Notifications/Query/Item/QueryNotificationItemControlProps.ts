// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Свойства элемента управления "Элемент извещения запроса".
 */
export interface QueryNotificationItemControlProps {
  /**
   * Сообщения.
   */
  messages?: string[];

  /**
   * Заголовок.
   */
  title: string;

  /**
   * Вариант.
   */
  variant: 'danger' | 'success' | 'warning';
}
