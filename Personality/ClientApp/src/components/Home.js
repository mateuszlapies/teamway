import {Button} from "reactstrap";

export default function Home() {
  return (
    <div className="d-table fill">
      <div className="fill-height d-table-cell text-center vertical-middle">
        <h1 className="m-3">Do you know who you are?</h1>
        <h3 className="m-3">Are you introvert or an extrovert?</h3>
        <h4 className="m-3">Find out now!</h4>
        <Button className="m-3" size="lg" href="/test" tag="a">Start The Test</Button>
      </div>
    </div>
  );
}
