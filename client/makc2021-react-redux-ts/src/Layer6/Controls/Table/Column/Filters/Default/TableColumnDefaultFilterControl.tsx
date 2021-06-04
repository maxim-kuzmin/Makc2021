// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { UseTableCellProps } from 'react-table';
import { DebounceInput } from 'react-debounce-input';

/**
 * Элемент управления "Фильтр по умолчанию колонки таблицы".
 */
export function TableColumnDefaultFilterControl<TRow extends object>({
  column
}: UseTableCellProps<TRow>) {
  const { filterValue, setFilter } = column;

  return (
    <DebounceInput
      className="form-control"
      minLength={1}
      debounceTimeout={600}
      value={filterValue || ''}
      onChange={(e) => {
        setFilter(e.target.value || undefined);
      }}
    />
  );
}
