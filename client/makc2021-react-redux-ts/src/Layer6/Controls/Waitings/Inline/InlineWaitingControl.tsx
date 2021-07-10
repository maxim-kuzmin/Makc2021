// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { SpinnerComponent } from 'react-element-spinner';
import { InlineWaitingControlProps } from './InlineWaitingControlProps';

/**
 * Элемент управления "Встроенное ожидание".
 */
export function InlineWaitingControl({ isVisible }: InlineWaitingControlProps) {
  return <SpinnerComponent loading={isVisible} position="inline" />;
}
