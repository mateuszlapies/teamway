import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";
import backend from "../helper/Backend";
import {Card, CardBody, CardHeader} from "reactstrap";

export default function Result() {
  let [session, setSession] = useState()
  let {id} = useParams()
  
  useEffect(() => {
    backend.get("Sessions?sessionId=" + id)
      .then(r => setSession(r.data))
  }, [id])

  if (session) {
    return (
      <div className="m-5">
        <div className="text-center">
          <h2>Your result: {session.score}</h2>
        </div>
        <div className="mt-5">
          {session.selections.map((element, index) => (
            <Card key={index} className="mb-3">
              <CardHeader>
                <p className="h4">{index + 1 + ". " + element.answer.question.text}</p>
              </CardHeader>
              <CardBody>
                <p className="h5">{element.answer.text}</p>
              </CardBody>
            </Card>
          ))}
        </div>
      </div>
    )
  } else {
    return <></>
  }

}