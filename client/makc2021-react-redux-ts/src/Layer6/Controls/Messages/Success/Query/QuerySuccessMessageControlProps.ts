// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { CommonMessageControlProps } from 'src/Layer6/Common/Message/Control/CommonMessageControlProps';

/**
 * Свойства элемента управления "Сообщение об успехе запроса".
 */
export interface QuerySuccessMessageControlProps
  extends CommonMessageControlProps {
  /**
   * Код запроса.
   */
  queryCode: string;
}
