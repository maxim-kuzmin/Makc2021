// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { SpinnerComponent } from 'react-element-spinner';
import { CommonWaitingControlProps } from 'src/Layer6/Common/Waiting/Control/CommonWaitingControlProps';

/**
 * Элемент управления "Глобальное ожидание".
 */
export function GlobalWaitingControl({ isVisible }: CommonWaitingControlProps) {
  return <SpinnerComponent loading={isVisible} position="global" />;
}
