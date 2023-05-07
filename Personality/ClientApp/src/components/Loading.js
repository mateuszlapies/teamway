import {Spinner} from "reactstrap";

export default function Loading() {
  return (
    <div className="d-table fill">
      <div className="fill-height d-table-cell text-center vertical-middle">
        <Spinner
          type="grow"
          color="secondary"
          className="status"
        >
          Loading...
        </Spinner>
      </div>
    </div>
  )
}