import cv2

face_cascades = cv2.CascadeClassifier(cv2.data.haarcascades + "haarcascade_frontalface_default.xml")

cap = cv2.VideoCapture('E:/Pyton/Bootcamp/Coding/Lesson/lesson_13_task_01/testvideo.mp4')

#img = cv2.imread('E:/Pyton/Bootcamp/Coding/Lesson/lesson_13_task_01/face.jpg')
#img_gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

#faces = face_cascades.detectMultiScale(img_gray)

#for (x, y, w, h) in faces:
    #cv2.rectangle(img, (x, y), (x + w, y + h), (255, 0, 0), 2)


#cv2.imshow('Result', img)
#cv2.waitKey(0)


while True:
    _, frame = cap.read()
    img_gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    faces = face_cascades.detectMultiScale(img_gray)

    for (x, y, w, h) in faces:
        cv2.rectangle(frame, (x, y), (x + w, y + h), (255, 0, 0), 2)

    cv2.imshow('Result', frame)

    if cv2.waitKey(1) & 0xff == ord('q'):
        break