// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { CommonErrorControlProps } from 'src/Layer6/Common/Error/Control/CommonErrorControlProps';

/**
 * Свойства элемента управления "Ошибка запроса".
 */
export interface QueryErrorControlProps extends CommonErrorControlProps {
  /**
   * Код запроса.
   */
  queryCode: string;
}
