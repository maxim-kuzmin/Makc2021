// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createContext } from 'react';
import { Configurator } from './Configurator';

/**
 * Контекст.
 */
export namespace Context {
  /**
   * Слой "Layer1".
   */
  export const Layer1 = createContext(Configurator.Layer1);

  /**
   * Слой "Layer5".
   */
  export const Layer5 = createContext(Configurator.Layer5);

  /**
   * Слой "Layer6".
   */
  export const Layer6 = createContext(Configurator.Layer6);
}
