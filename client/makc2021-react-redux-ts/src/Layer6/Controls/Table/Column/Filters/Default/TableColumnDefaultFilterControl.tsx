import { UseTableCellProps } from 'react-table';
import Form from 'react-bootstrap/Form';

/**
 * Элемент управления "Фильтр по умолчанию колонки таблицы".
 */
export function TableColumnDefaultFilterControl<TRow extends object>(
  props: UseTableCellProps<TRow>
) {
  const { filterValue, preFilteredRows, setFilter } = props.column;

  const count = preFilteredRows && preFilteredRows.length;

  return (
    <Form.Control
      as="input"
      value={filterValue || ''}
      onChange={(e) => {
        setFilter(e.target.value || undefined); // Set undefined to remove the filter entirely
      }}
      placeholder={`Search ${count} records...`}
    />
  );
}
