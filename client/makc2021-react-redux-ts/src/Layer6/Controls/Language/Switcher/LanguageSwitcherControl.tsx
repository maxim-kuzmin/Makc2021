// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useContext } from 'react';
import FormControl from 'react-bootstrap/FormControl';
import { Context } from 'src/Context';

/**
 * Элемент управления "Переключатель языка".
 */
export function LanguageSwitcherControl() {
  const contextOfLayer1 = useContext(Context.Layer1);

  const language = contextOfLayer1.getModule().localizationLanguage;

  return (
    <FormControl
      as="select"
      value={language.current}
      onChange={(e) => language.change(e.target.value)}
      style={{ width: '7em' }}
    >
      <option value="en">English</option>
      <option value="ru">Русский</option>
    </FormControl>
  );
}
