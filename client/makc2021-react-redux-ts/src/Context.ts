// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createContext } from 'react';
import { Context as Layer1Context } from './Layer1/Context';
import { Context as Layer5Context } from './Layer5/Context';
import { Context as Layer6Context } from './Layer6/Context';

/**
 * Значение контекста.
 */
export class ContextValue {
  /**
   * Слой "Layer1".
   */
  Layer1 = new Layer1Context();

  /**
   * Слой "Layer5".
   */
  Layer5 = new Layer5Context();

  /**
   * Слой "Layer6".
   */
  Layer6 = new Layer6Context();
}

/**
 * Значение контекста по умолчанию.
 */
export const defaultContextValue = new ContextValue();

/**
 * Контекст.
 */
export const Context = createContext(defaultContextValue);
