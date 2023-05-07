import {useEffect, useState} from "react";
import backend from "../helper/Backend";
import {Button, Card, CardBody, CardHeader, Form, FormGroup, Input, Label} from "reactstrap";
import {useNavigate} from "react-router-dom";
import Loading from "./Loading";
import {useNotificationContext} from "../contexts/NotificationContext";
import NotificationType from "../helper/NotificationType";

export default function Test() {
  let navigate = useNavigate()
  let [questions, setQuestions] = useState();
  let [selections, setSelections] = useState([]);
  let [processing, setProcessing] = useState(false);
  let addNotification = useNotificationContext();

  useEffect(() => {
    backend.get("Questions")
      .then(r => setQuestions(r.data))
      .catch(() => addNotification(NotificationType.Error, "For some reason we have not questions for you at this time"))
  }, [])

  const validate = () => {
    return selections.length === questions.length;
  }

  const onSubmit = (e) => {
    e.preventDefault()
    setProcessing(true)
    if (validate()) {
      addNotification(NotificationType.Processing, "Your responses are being saved...")
      backend.put("Sessions", selections.map(element => element.answer))
        .then(r => {
          addNotification(NotificationType.Info, "Your responses have been saved")
          navigate("/result/" + r.data.id)
        })
        .catch(() => {
          addNotification(NotificationType.Error, "For some reason we cannot save your responses");
          setProcessing(false);
        })
    } else {
      addNotification(NotificationType.Error, "All questions need an answer!");
      setProcessing(false);
    }
  }

  const onChange = (e) => {
      setSelections(prevState => prevState.filter(element => element.question !== e.target.name))
      setSelections(prevState => [...prevState, { question: e.target.name, answer: e.target.value }])
  }

  if (questions) {
    return (
      <div className="m-5">
        <Form onSubmit={onSubmit}>
          {questions.map((question, index) => (
            <Card key={index} className="mb-3">
              <CardHeader>
                <p className="h4 m-0">{index + 1 + ". " + question.text}</p>
              </CardHeader>
              <CardBody>
                {question.answers.map((answer, answerIndex) => (
                  <FormGroup check key={answerIndex}>
                    <Input key={answerIndex} type="radio" name={index} value={answer.id} onChange={onChange} />
                    <Label check>
                      <p className="h5 m-0">{answer.text}</p>
                    </Label>
                  </FormGroup>
                ))}
              </CardBody>
            </Card>
          ))}
          <Button type="submit" size="lg" className="mt-3 float-end" disabled={processing}>Submit Your Answers</Button>
        </Form>
      </div>
    )
  } else {
    return <Loading />
  }
}