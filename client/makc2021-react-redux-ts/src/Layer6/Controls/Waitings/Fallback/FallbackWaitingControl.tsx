// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { SpinnerComponent } from 'react-element-spinner';

/**
 * Элемент управления "Резервное ожидание".
 */
export function FallbackWaitingControl() {
  return <SpinnerComponent loading={true} position="global" />;
}
