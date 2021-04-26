// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { UseTableCellProps } from 'react-table';
import FormControl from 'react-bootstrap/FormControl';

/**
 * Элемент управления "Фильтр по умолчанию колонки таблицы".
 */
export function TableColumnDefaultFilterControl<TRow extends object>({
  column
}: UseTableCellProps<TRow>) {
  const { filterValue, setFilter } = column;

  return (
    <FormControl
      as="input"
      value={filterValue || ''}
      onChange={(e) => {
        setFilter(e.target.value || undefined);
      }}
    />
  );
}
