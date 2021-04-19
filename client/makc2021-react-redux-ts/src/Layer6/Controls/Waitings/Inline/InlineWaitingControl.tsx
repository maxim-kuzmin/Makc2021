// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { SpinnerComponent } from 'react-element-spinner';
import { CommonWaitingControlProps } from 'src/Layer6/Common/Waiting/Control/CommonWaitingControlProps';

/**
 * Элемент управления "Встроенное ожидание".
 */
export function InlineWaitingControl({ isVisible }: CommonWaitingControlProps) {
  return <SpinnerComponent loading={isVisible} position="inline" />;
}
